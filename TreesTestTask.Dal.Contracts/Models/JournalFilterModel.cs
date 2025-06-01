namespace TreesTestTask.Dal.Contracts.Models
{
	public class JournalFilterModel
	{
		public DateTimeOffset? From { get; set; }
		public DateTimeOffset? To { get; set; }
		public string? SearchText { get; set; }
	}
}