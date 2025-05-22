using Microsoft.AspNetCore.Mvc;

namespace TreesTestTask.Core.Contracts.Models
{
	public class JournalEntryGetRangeRequestModel
	{
		[FromQuery]
		public int Skip { get; set; }
		[FromQuery]
		public int Take { get; set; }
		[FromBody]
		public JournalEntryFilter Filter { get; set; }
	}
}