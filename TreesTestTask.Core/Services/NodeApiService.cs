using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Common.Exceptions;
using TreesTestTask.Core.Contracts.Models;
using TreesTestTask.Core.Contracts.Services;
using TreesTestTask.Dal.Contracts.Models;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	[ApiController]
	[Route("api.user.tree.node.[action]")]
	[AllowAnonymous]
	public class NodeApiService : BaseApiService, INodeApiService
	{
		private readonly INodeRepository _nodeRepository;

		public NodeApiService(ILogger<NodeApiService> logger,
		                      IMapper mapper,
		                      INodeRepository nodeRepository) : base(logger, mapper)
		{
			_nodeRepository = nodeRepository;
		}

		[HttpPost]
		[ActionName("create")]
		public async Task CreateNode([FromQuery] CreateNodeRequestModel request)
		{
			var tree = await _nodeRepository.GetTreeByNameAsync(request.TreeName!);

			if (tree == null)
				throw new ResourceNotExistException(nameof(tree));

			await _nodeRepository.CreateNodeAsync(new NodeDto
			{
				ParentId = request.ParentNodeId,
				Name = request.NodeName!,
				TreeId = tree.Id
			});
		}

		[HttpPost]
		[ActionName("delete")]
		public async Task DeleteNode([FromQuery] DeleteNodeRequestModel request)
		{
			await _nodeRepository.DeleteNodeAsync(request.NodeId, request.TreeName!);
		}

		[HttpPost]
		[ActionName("rename")]
		public async Task RenameNode([FromQuery] RenameNodeRequestModel request)
		{
			var tree = await _nodeRepository.GetTreeByNameAsync(request.TreeName!);

			if (tree is null)
				throw new ResourceNotExistException(nameof(tree));
			var node = await _nodeRepository.GetNodeAsync(request.NodeId, tree.Id);
			if (node is null)
				throw new ResourceNotExistException(nameof(node));

			node.Name = request.NewNodeName!;

			await _nodeRepository.UpdateNodeAsync(node);
		}
	}
}