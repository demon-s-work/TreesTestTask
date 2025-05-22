using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Dal.Contracts.Repositories
{
	public interface IJournalRepository
	{
		public Task AddJournalRecordAsync(JournalRecordDto journalRecordDto);
		public Task<JournalRecord?> GetByIdAsync(int id);
	}
}