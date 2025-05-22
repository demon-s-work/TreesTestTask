using System.Text.Json.Serialization;

namespace TreesTestTask.Core.Contracts.Models
{
	public class JournalEntryFilter
	{
		public DateTimeOffset? From { get; set; }
		public DateTimeOffset? To { get; set; }
		[JsonPropertyName("search")]
		public string? SearchText { get; set; }
	}
}