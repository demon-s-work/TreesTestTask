using Microsoft.Extensions.Logging;
using TreesTestTask.Common;
using TreesTestTask.Migrations.Context;

namespace TreesTestTask.Migrations.Repositories.Abstractions
{
	public abstract class BaseRepository : BaseService
	{
		protected readonly ApplicationDbContext _context;

		protected BaseRepository(
			ApplicationDbContext context,
			ILogger logger) : base(logger)
		{
			_context = context;
		}

		protected async Task SaveChangesAsync()
		{
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				throw;
			}
		}
	}
}