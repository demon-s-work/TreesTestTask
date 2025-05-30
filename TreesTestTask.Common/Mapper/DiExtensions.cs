using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TreesTestTask.Common.Mapper
{
	public static class DiExtensions
	{
		public static void AddMapster(this IServiceCollection services)
		{
			var config = new TypeAdapterConfig();
			new RegisterMapper().Register(config);
			services.AddSingleton(config);
			services.AddScoped<IMapper, MapsterMapper.Mapper>();
		}
	}
}