using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Core.Contracts.Models
{
	public class GetOrCreateTreeResponseModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<NodeDto> Children { get; set; }
	}
}