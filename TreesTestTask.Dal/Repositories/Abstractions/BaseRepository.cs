using MapsterMapper;
using Microsoft.Extensions.Logging;
using TreesTestTask.Common;
using TreesTestTask.Migrations.Context;

namespace TreesTestTask.Migrations.Repositories.Abstractions
{
	public abstract class BaseRepository : BaseService
	{
		protected readonly ApplicationDbContext Context;
		protected readonly IMapper Mapper;

		protected BaseRepository(
			ApplicationDbContext context,
			ILogger logger,
			IMapper mapper) : base(logger)
		{
			Context = context;
			Mapper = mapper;
		}

		protected async Task SaveChangesAsync()
		{
			try
			{
				await Context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				Logger.LogError(e.Message);
				throw;
			}
		}
	}
}