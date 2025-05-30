using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Dal.Contracts.Repositories
{
	public interface IJournalRepository
	{
		public Task<JournalRecordDto> AddJournalRecordAsync(JournalRecordDto journalRecordDto);
		public Task<JournalRecord?> GetByIdAsync(int id);
		public Task<IEnumerable<JournalRecordInfoModel>> GetRange(JournalFilterModel filter, int skip, int take);
	}
}