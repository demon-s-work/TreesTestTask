using Microsoft.AspNetCore.Mvc;

namespace TreesTestTask.Services.Abstractions
{
	[ApiController]
	public abstract class BaseApiService
	{
		private readonly ILogger _logger;

		protected BaseApiService(ILogger logger)
		{
			_logger = logger;
		}
	}
}