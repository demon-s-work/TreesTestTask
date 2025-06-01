using System.ComponentModel.DataAnnotations;

namespace TreesTestTask.Core.Contracts.Models
{
	public class JournalEntriesGetRangeRequestModel
	{
		[Required]
		public int Skip { get; set; }
		[Required]
		public int Take { get; set; }
	}
}