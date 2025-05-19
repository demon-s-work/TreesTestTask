using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Common;

namespace TreesTestTask.Services.Abstractions
{
	[ApiController]
	public abstract class BaseApiService : BaseService
	{
		protected BaseApiService(ILogger logger) : base(logger)
		{
		}
	}
}