using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	public class TreeApiService : BaseApiService
	{
		public TreeApiService(ILogger<TreeApiService> logger) : base(logger)
		{
		}
	}
}