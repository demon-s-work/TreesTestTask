using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Migrations.Context;
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

		public async Task AddJournalRecordAsync(JournalRecordDto journalRecordDto)
		{
			await _context.JournalRecords.AddAsync(_mapper.Map<JournalRecord>(journalRecordDto));
			await SaveChangesAsync();
		}

		public async Task<JournalRecord?> GetByIdAsync(int id)
		{
			return await _context.JournalRecords.SingleOrDefaultAsync(j => j.Id == id);
		}
	}
}