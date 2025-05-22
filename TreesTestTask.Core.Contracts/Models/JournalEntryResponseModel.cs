namespace TreesTestTask.Core.Contracts.Models
{
	public class JournalEntryResponseModel
	{
		public int Id { get; set; }
		public int EventId { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
	}
}