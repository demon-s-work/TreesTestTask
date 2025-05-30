using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Core.Contracts.Models;
using TreesTestTask.Core.Contracts.Models.Abstractions;

namespace TreesTestTask.Core.Contracts.Services
{
	public interface IJournalApiService
	{
		Task<JournalEntriesGetRangeResponseModel> GetRangeAsync(JournalEntriesGetRangeRequestModel request, FilterRequestModel filter);

		Task<JournalEntryResponseModel> GetSingle([FromQuery] int id);
	}
}