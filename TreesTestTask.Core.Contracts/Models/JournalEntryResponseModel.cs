﻿namespace TreesTestTask.Core.Contracts.Models
{
	public class JournalEntryResponseModel
	{
		public int Id { get; set; }
		public string EventId { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public string Text { get; set; }
	}
}