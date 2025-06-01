using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Core.Contracts.Models;

namespace TreesTestTask.Core.Contracts.Services
{
	public interface IJournalApiService
	{
		Task<JournalEntriesGetRangeResponseModel> GetRangeAsync(JournalEntriesGetRangeRequestModel request, JournalEntryFilterRequestModel journalEntryFilter);

		Task<JournalEntryResponseModel?> GetSingle([FromQuery] int id);
	}
}