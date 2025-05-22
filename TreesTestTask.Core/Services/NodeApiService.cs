using TreesTestTask.Core.Contracts.Services;
using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	public class NodeApiService : BaseApiService, INodeApiService
	{
		public NodeApiService(ILogger<NodeApiService> logger) : base(logger)
		{
		}
	}
}