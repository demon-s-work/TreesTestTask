namespace TreesTestTask.Dal.Contracts.Models
{
	public class JournalRecordInfoModel
	{
		public int Id { get; set; }
		public string EventId { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
	}
}