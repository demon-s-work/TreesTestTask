using Newtonsoft.Json;
using TreesTestTask.Common.Mapper;
using TreesTestTask.Core.Contracts.Services;
using TreesTestTask.Dal.Contracts.Repositories;
using TreesTestTask.Middlewares;
using TreesTestTask.Migrations.Extensions;
using TreesTestTask.Migrations.Repositories;
using TreesTestTask.Services;

namespace TreesTestTask;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers()
		       .AddNewtonsoftJson(opts => {
			       opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
		       });
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("Default"));
		builder.Services.AddMapster();

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

		app.UseMiddleware<SecureExceptionMiddleware>();

		app.UseHttpsRedirection();
		app.UseAuthorization();
		app.MapControllers();


		app.Run();
	}
}