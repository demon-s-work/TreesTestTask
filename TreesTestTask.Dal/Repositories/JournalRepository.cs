using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Migrations.Context;
using TreesTestTask.Migrations.Extensions;
using TreesTestTask.Migrations.Repositories.Abstractions;

namespace TreesTestTask.Migrations.Repositories
{
	public class JournalRepository : BaseRepository, IJournalRepository
	{
		public JournalRepository(
			ApplicationDbContext context,
			ILogger<JournalRepository> logger,
			IMapper mapper) : base(context, logger, mapper)
		{
		}

		public async Task<JournalRecordDto> AddJournalRecordAsync(JournalRecordDto journalRecordDto)
		{
			var journalRecord = _mapper.Map<JournalRecord>(journalRecordDto);
			await _context.JournalRecords.AddAsync(journalRecord);
			await SaveChangesAsync();
			return _mapper.Map<JournalRecordDto>(journalRecord);
		}

		public async Task<JournalRecord?> GetByIdAsync(int id)
		{
			return await _context.JournalRecords.SingleOrDefaultAsync(j => j.Id == id);
		}

		public async Task<IEnumerable<JournalRecordInfoModel>> GetRange(JournalFilterModel filter, int skip, int take)
		{
			return await _context.JournalRecords
			                     .AsNoTracking()
			                     .ApplyFilter(filter)
			                     .Skip(skip)
			                     .Take(take)
			                     .ProjectToType<JournalRecordInfoModel>()
			                     .ToListAsync();
		}
	}
}