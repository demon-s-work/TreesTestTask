using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Dal.Contracts.Repositories
{
	public interface INodeRepository
	{
		Task<NodeDto> GetOrCreateRootNodeAsync(string name);
		Task<NodeDto?> GetNodeAsync(int id, int treeId);
		Task<NodeDto?> GetTreeByNameAsync(string name);
		Task CreateNodeAsync(NodeDto node);
		Task DeleteNodeAsync(int nodeId, string treeName);
		Task UpdateNodeAsync(NodeDto node);
	}
}