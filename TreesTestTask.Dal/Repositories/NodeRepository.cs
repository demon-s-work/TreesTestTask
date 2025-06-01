using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreesTestTask.Common.Exceptions;
using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Migrations.Context;
using TreesTestTask.Migrations.Repositories.Abstractions;

namespace TreesTestTask.Migrations.Repositories
{
	public class NodeRepository : BaseRepository, INodeRepository
	{
		public NodeRepository(
			ApplicationDbContext context,
			ILogger<NodeRepository> logger,
			IMapper mapper) : base(context, logger, mapper)
		{
		}

		public async Task<NodeDto> GetOrCreateRootNodeAsync(string name)
		{
			var tree = await _context.Nodes
			                         .FromSqlInterpolated($"SELECT * from get_nodes_hierarchy({name})")
			                         .ToListAsync();
			var existingNode = tree.FirstOrDefault(n => n.ParentId == null && n.Name == name);

			if (existingNode is not null)
				return _mapper.Map<NodeDto>(existingNode);

			var inserted = await _context.Nodes.AddAsync(new Node
			{
				Name = name
			});
			await SaveChangesAsync();
			inserted.Entity.TreeId = inserted.Entity.Id;
			await SaveChangesAsync();

			return _mapper.Map<NodeDto>(inserted.Entity);
		}

		public async Task<NodeDto?> GetNodeAsync(int id, int treeId)
		{
			var node = await _context.Nodes
			                         .AsNoTracking()
			                         .SingleOrDefaultAsync(n => n.Id == id && n.TreeId == treeId);
			return _mapper.Map<NodeDto>(node);
		}

		public async Task<NodeDto?> GetTreeByNameAsync(string name)
		{
			var treeNode = await _context.Nodes
			                             .AsNoTracking()
			                             .SingleOrDefaultAsync(n => n.Name == name && n.ParentId == null);
			return _mapper.Map<NodeDto>(treeNode);
		}

		public async Task CreateNodeAsync(NodeDto node)
		{
			var parentNode = await _context.Nodes.SingleOrDefaultAsync(n => n.Id == node.ParentId);
			if (parentNode is null)
				throw new ResourceNotExistException(nameof(parentNode));
			if (parentNode.TreeId != node.TreeId)
				throw new SecureException("The tree ID of the created node is different from the tree ID of the parent node");
			await _context.Nodes.AddAsync(_mapper.Map<Node>(node));
			await SaveChangesAsync();
		}

		public async Task DeleteNodeAsync(int nodeId, string treeName)
		{
			var tree = await GetTreeByNameAsync(treeName);
			if (tree is null)
				throw new ResourceNotExistException(nameof(tree));

			var node = await _context.Nodes
			                         .Include(node => node.Children)
			                         .SingleOrDefaultAsync(n => n.Id == nodeId && n.TreeId == tree.Id);
			if (node is null)
				throw new ResourceNotExistException(nameof(node));
			if (node.Children.Any())
				throw new SecureException("You have to delete all children nodes first");

			_context.Remove(node);
			await SaveChangesAsync();
		}

		public async Task UpdateNodeAsync(NodeDto node)
		{
			_context.Nodes.Update(_mapper.Map<Node>(node));
			await SaveChangesAsync();
		}

		public async Task<NodeDto?> GetNodeAsync(string name, int parentNodeId)
		{
			var tree = await _context.Nodes.SingleOrDefaultAsync(n => n.Name == name && n.ParentId == null);
			if (tree is null)
			{
				return null;
			}
			var parentNode = await _context.Nodes.SingleOrDefaultAsync(n => n.ParentId == parentNodeId && n.TreeId == tree.Id);
			return _mapper.Map<NodeDto>(parentNode);
		}
	}
}