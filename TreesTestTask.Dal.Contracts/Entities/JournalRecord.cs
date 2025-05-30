namespace TreesTestTask.Dal.Contracts.Entities
{
	public class JournalRecord : BaseEntity
	{
		public DateTimeOffset CreatedAt { get; set; }

		public string EventId { get; set; }
		public string QueryParameters { get; set; }
		public string BodyParameters { get; set; }
		public string StackTrace { get; set; }
	}
}