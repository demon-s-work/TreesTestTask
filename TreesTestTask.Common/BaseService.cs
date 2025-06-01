using Microsoft.Extensions.Logging;

namespace TreesTestTask.Common
{
	public abstract class BaseService
	{
		protected readonly ILogger Logger;

		protected BaseService(ILogger logger)
		{
			Logger = logger;
		}
	}
}