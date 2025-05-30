using TreesTestTask.Core.Contracts.Models;

namespace TreesTestTask.Core.Contracts.Services
{
	public interface INodeApiService
	{
		Task CreateNode(CreateNodeRequestModel request);
		Task DeleteNode(DeleteNodeRequestModel request);
		Task RenameNode(RenameNodeRequestModel request);
	}
}