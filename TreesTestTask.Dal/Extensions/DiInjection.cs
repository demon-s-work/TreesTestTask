using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TreesTestTask.Migrations.Context;

namespace TreesTestTask.Migrations.Extensions
{
	public static class DiInjection
	{
		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string? connectionString)
		{
			if (connectionString is null)
				throw new ArgumentNullException(nameof(connectionString));
			
			services.AddDbContext<ApplicationDbContext>(options => 
				options.UseNpgsql(connectionString)
			);
			return services;
		}
	}
}