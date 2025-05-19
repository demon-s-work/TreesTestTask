using Microsoft.Extensions.Logging;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Migrations.Context;
using TreesTestTask.Migrations.Repositories.Abstractions;

namespace TreesTestTask.Migrations.Repositories
{
	public class JournalRepository : BaseRepository, IJournalRepository
	{
		public JournalRepository(ApplicationDbContext context, ILogger<JournalRepository> logger) : base(context, logger)
		{
		}
	}
}