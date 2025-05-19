using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	public class NodeApiService : BaseApiService
	{
		public NodeApiService(ILogger<NodeApiService> logger) : base(logger)
		{
		}
	}
}