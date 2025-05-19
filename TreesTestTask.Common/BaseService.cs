using Microsoft.Extensions.Logging;

namespace TreesTestTask.Common
{
	public abstract class BaseService
	{
		protected readonly ILogger _logger;

		protected BaseService(ILogger logger)
		{
			_logger = logger;
		}
	}
}