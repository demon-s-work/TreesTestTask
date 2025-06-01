using System.ComponentModel.DataAnnotations;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Core.Contracts.Models;
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
		public async Task<JournalEntriesGetRangeResponseModel> GetRangeAsync([FromQuery] JournalEntriesGetRangeRequestModel request,
		                                                                     [FromBody, Required] JournalEntryFilterRequestModel journalEntryFilter)
		{
			var journalInfo = await _journalRepository.GetRange(_mapper.Map<JournalFilterModel>(journalEntryFilter), request.Skip, request.Take);

			return new JournalEntriesGetRangeResponseModel
			{
				Skip = request.Skip, Take = request.Take,
				Items = journalInfo
			};
		}

		[HttpPost]
		[ActionName("getSingle")]
		public async Task<JournalEntryResponseModel?> GetSingle([FromQuery, Required] int id)
		{
			var journalEntry = await _journalRepository.GetByIdAsync(id);
			if (journalEntry == null)
				return null;
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