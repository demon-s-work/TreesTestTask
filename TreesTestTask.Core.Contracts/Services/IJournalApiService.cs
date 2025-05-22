using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Core.Contracts.Models;

namespace TreesTestTask.Core.Contracts.Services
{
	public interface IJournalApiService
	{
		Task GetRange(JournalEntryGetRangeRequestModel request);

		Task<JournalEntryResponseModel> GetSingle([FromQuery] int id);
	}
}