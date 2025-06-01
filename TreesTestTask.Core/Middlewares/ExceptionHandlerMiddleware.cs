using System.Text;
using Newtonsoft.Json;
using TreesTestTask.Common.Exceptions;
using TreesTestTask.Dal.Contracts.Models;
using TreesTestTask.Dal.Contracts.Repositories;

namespace TreesTestTask.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlerMiddleware> _logger;

		public ExceptionHandlerMiddleware(
			RequestDelegate next,
			ILogger<ExceptionHandlerMiddleware> logger)

		{
			_next = next;
			_logger = logger;
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
				var body = "";
				context.Request.EnableBuffering();
				using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
				{
					body = await reader.ReadToEndAsync();
					context.Request.Body.Position = 0;
				}

				var journalRecord = new JournalRecordDto
				{
					CreatedAt = DateTime.UtcNow,
					QueryParameters = JsonConvert.SerializeObject(queryParams),
					BodyParameters = body,
					EventId = context.TraceIdentifier,
					StackTrace = ex.StackTrace ?? string.Empty
				};

				await journalRepository.AddJournalRecordAsync(journalRecord);

				context.Response.ContentType = "application/json";
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;

				object response;
				if (ex is SecureException secureEx)
				{
					response = new
					{
						type = secureEx.GetType().Name,
						id = context.TraceIdentifier,
						data = new { message = secureEx.Message }
					};
				}
				else
				{
					response = new
					{
						type = "Exception",
						id = context.TraceIdentifier,
						data = new { message = $"Internal server error ID = {context.TraceIdentifier}" }
					};
					if (ex is BaseException baseEx)
					{
						context.Response.StatusCode = baseEx.ResponseStatusCode;
					}
				}

				await context.Response.WriteAsJsonAsync(response);
			}
		}
	}
}