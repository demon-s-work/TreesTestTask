namespace TreesTestTask.Dal.Contracts.Models
{
	public class JournalRecordDto
	{
		public int Id { get; set; }
		public DateTimeOffset Timestamp { get; set; }
		public int EventId { get; set; }
		public string QueryParameters { get; set; }
		public string BodyParameters { get; set; }
		public string StackTrace { get; set; }
	}
}