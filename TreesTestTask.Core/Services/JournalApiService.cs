using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Core.Contracts.Models;
using TreesTestTask.Core.Contracts.Services;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	[ApiController]
	[Route("api.user.journal.[action]")]
	[AllowAnonymous]
	public class JournalApiService : BaseApiService, IJournalApiService
	{
		private IJournalRepository _journalRepository;
		private IMapper _mapper;

		public JournalApiService(
			ILogger<JournalApiService> logger,
			IJournalRepository journalRepository,
			IMapper mapper) : base(logger)
		{
			_journalRepository = journalRepository;
			_mapper = mapper;
		}

		[HttpPost]
		[ActionName("getRange")]
		public async Task GetRange(JournalEntryGetRangeRequestModel request)
		{
		}

		[HttpPost]
		[ActionName("getSingle")]
		public async Task<JournalEntryResponseModel> GetSingle(int id)
		{
			return _mapper.Map<JournalEntryResponseModel>(await _journalRepository.GetByIdAsync(id));
		}
	}
}