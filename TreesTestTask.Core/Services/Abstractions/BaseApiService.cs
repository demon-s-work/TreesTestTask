using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using TreesTestTask.Common;

namespace TreesTestTask.Services.Abstractions
{
	[ApiController]
	public abstract class BaseApiService : BaseService
	{
		protected IMapper Mapper;

		protected BaseApiService(ILogger logger, IMapper mapper) : base(logger)
		{
			Mapper = mapper;
		}
	}
}