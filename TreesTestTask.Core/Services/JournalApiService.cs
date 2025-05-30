using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Core.Contracts.Models;
using TreesTestTask.Core.Contracts.Models.Abstractions;
using TreesTestTask.Core.Contracts.Services;
using TreesTestTask.Dal.Contracts.Models;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	[ApiController]
	[Route("api.user.journal.[action]")]
	[AllowAnonymous]
	public class JournalApiService : BaseApiService, IJournalApiService
	{
		private readonly IJournalRepository _journalRepository;

		public JournalApiService(
			ILogger<JournalApiService> logger,
			IJournalRepository journalRepository,
			IMapper mapper) : base(logger, mapper)
		{
			_journalRepository = journalRepository;
			_mapper = mapper;
		}

		[HttpPost]
		[ActionName("getRange")]
		public async Task<JournalEntriesGetRangeResponseModel> GetRangeAsync([FromQuery] JournalEntriesGetRangeRequestModel request, [FromBody] FilterRequestModel filter)
		{
			var journalInfo = await _journalRepository.GetRange(_mapper.Map<JournalFilterModel>(filter), request.Skip, request.Take);

			return new JournalEntriesGetRangeResponseModel
			{
				Skip = request.Skip, Take = request.Take,
				Items = journalInfo
			};
		}

		[HttpPost]
		[ActionName("getSingle")]
		public async Task<JournalEntryResponseModel> GetSingle([FromQuery] int id)
		{
			var journalEntry = await _journalRepository.GetByIdAsync(id);
			return new JournalEntryResponseModel
			{
				Id = journalEntry.Id,
				EventId = journalEntry.EventId,
				CreatedAt = journalEntry.CreatedAt,
				Text = $"Request ID = {journalEntry.EventId}\nQuery = {journalEntry.QueryParameters}\nBody = {journalEntry.BodyParameters}\nid = {journalEntry.Id}\n{journalEntry.StackTrace}",
			};
		}
	}
}