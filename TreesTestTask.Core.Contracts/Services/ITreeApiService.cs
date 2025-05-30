using TreesTestTask.Core.Contracts.Models;

namespace TreesTestTask.Core.Contracts.Services
{
	public interface ITreeApiService
	{
		Task<GetOrCreateTreeResponseModel> GetOrCreateTree(string treeName);
	}
}