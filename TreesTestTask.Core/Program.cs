using TreesTestTask.Core.Contracts.Services;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Middlewares;
using TreesTestTask.Migrations.Extensions;
using TreesTestTask.Migrations.Repositories;
using TreesTestTask.Services;
using TreesTestTask.Settings;

namespace TreesTestTask;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("Default"));
		builder.Services.AddAutoMapper(typeof(AppMappingProfile));

		builder.Services.AddScoped<IJournalApiService, JournalApiService>();
		builder.Services.AddScoped<IJournalRepository, JournalRepository>();

		builder.Services.AddScoped<INodeApiService, NodeApiService>();
		builder.Services.AddScoped<INodeRepository, NodeRepository>();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();
		app.UseAuthorization();
		app.MapControllers();

		app.UseMiddleware<SecureExceptionMiddleware>();

		app.Run();
	}
}