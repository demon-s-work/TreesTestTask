namespace TreesTestTask.Core.Contracts.Models
{
	public class JournalEntryGetRangeResponseModel
	{
		public int Skip { get; set; }
		public int Take { get; set; }
		public IEnumerable<JournalEntryResponseModel> Items { get; set; }
	}
}