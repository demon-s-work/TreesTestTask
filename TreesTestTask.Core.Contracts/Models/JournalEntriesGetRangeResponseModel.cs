using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Core.Contracts.Models
{
	public class JournalEntriesGetRangeResponseModel
	{
		public int Skip { get; set; }
		public int Take { get; set; }
		public IEnumerable<JournalRecordInfoModel> Items { get; set; }
	}
}