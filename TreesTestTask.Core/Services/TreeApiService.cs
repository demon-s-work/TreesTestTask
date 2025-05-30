using System.ComponentModel.DataAnnotations;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Core.Contracts.Models;
using TreesTestTask.Core.Contracts.Services;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	[ApiController]
	[Route("api.user.tree.[action]")]
	[AllowAnonymous]
	public class TreeApiService : BaseApiService, ITreeApiService
	{
		private readonly INodeRepository _nodeRepository;

		public TreeApiService(ILogger<TreeApiService> logger,
		                      IMapper mapper,
		                      INodeRepository nodeRepository) : base(logger, mapper)
		{
			_nodeRepository = nodeRepository;
		}

		[HttpPost]
		[ActionName("get")]
		public async Task<GetOrCreateTreeResponseModel> GetOrCreateTree([FromQuery] [Required] string treeName)
		{
			var result = await _nodeRepository.GetOrCreateRootNodeAsync(treeName);
			return _mapper.Map<GetOrCreateTreeResponseModel>(result);
		}
	}
}