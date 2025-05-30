namespace TreesTestTask.Dal.Contracts.Models
{
	public class NodeDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public int? TreeId { get; set; }
		public ICollection<NodeDto> Children { get; set; } = new List<NodeDto>();
	}
}