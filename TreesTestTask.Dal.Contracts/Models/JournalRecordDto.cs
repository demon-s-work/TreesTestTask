namespace TreesTestTask.Dal.Contracts.Models
{
	public class JournalRecordDto
	{
		public int Id { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public string EventId { get; set; }
		public string QueryParameters { get; set; }
		public string BodyParameters { get; set; }
		public string StackTrace { get; set; }
	}
}