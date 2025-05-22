using AutoMapper;
using Microsoft.Extensions.Logging;
using TreesTestTask.Common;
using TreesTestTask.Migrations.Context;

namespace TreesTestTask.Migrations.Repositories.Abstractions
{
	public abstract class BaseRepository : BaseService
	{
		protected readonly ApplicationDbContext _context;
		protected readonly IMapper _mapper;

		protected BaseRepository(
			ApplicationDbContext context,
			ILogger logger,
			IMapper mapper) : base(logger)
		{
			_context = context;
			_mapper = mapper;
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