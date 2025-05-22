using AutoMapper;
using Microsoft.Extensions.Logging;
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
	}
}