using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Common;

namespace TreesTestTask.Services.Abstractions
{
	[ApiController]
	public abstract class BaseApiService : BaseService
	{
		protected IMapper _mapper;

		protected BaseApiService(ILogger logger, IMapper mapper) : base(logger)
		{
			_mapper = mapper;
		}
	}
}