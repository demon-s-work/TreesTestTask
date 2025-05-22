using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreesTestTask.Dal.Contracts.Entities
{
	public class JournalRecord
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTimeOffset Timestamp { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EventId { get; set; }
		public string QueryParameters { get; set; }
		public string BodyParameters { get; set; }
		public string StackTrace { get; set; }
	}
}