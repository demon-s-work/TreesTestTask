using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using TreesTestTask.Dal.Contracts.Models;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Exceptions;

namespace TreesTestTask.Middlewares
{
	public class SecureExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<SecureExceptionMiddleware> _logger;
		private readonly IMapper _mapper;

		public SecureExceptionMiddleware(
			RequestDelegate next,
			ILogger<SecureExceptionMiddleware> logger,
			IMapper mapper)
		{
			_next = next;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				var journalRepository = context.RequestServices.GetRequiredService<IJournalRepository>();
				var queryParams = context.Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
				string body = "";
				context.Request.EnableBuffering();
				using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
				{
					body = await reader.ReadToEndAsync();
					context.Request.Body.Position = 0;
				}

				var eventId = Guid.NewGuid();
				var journalRecord = new JournalRecordDto
				{
					Timestamp = DateTime.UtcNow,
					QueryParameters = JsonConvert.SerializeObject(queryParams),
					BodyParameters = body,
					StackTrace = ex.StackTrace
				};

				await journalRepository.AddJournalRecordAsync(journalRecord);

				// Prepare response
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;

				object response;
				if (ex is SecureException secureEx)
				{
					response = new
					{
						type = secureEx.GetType().Name,
						id = eventId,
						data = new { message = secureEx.Message }
					};
				}
				else
				{
					response = new
					{
						type = "Exception",
						id = eventId,
						data = new { message = $"Internal server error ID = {eventId}" }
					};
				}

				await context.Response.WriteAsJsonAsync(response);
			}
		}
	}
}