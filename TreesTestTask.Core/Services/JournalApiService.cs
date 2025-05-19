using TreesTestTask.Services.Abstractions;

namespace TreesTestTask.Services
{
	public class JournalApiService : BaseApiService
	{
		public JournalApiService(ILogger<JournalApiService> logger) : base(logger)
		{
		}
	}
}