using System.ComponentModel.DataAnnotations;

namespace TreesTestTask.Dal.Contracts.Entities
{
	public class Node : BaseEntity
	{
		[Required]
		[MaxLength(64)]
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public virtual Node? Parent { get; set; }

		public int? TreeId { get; set; }
		public virtual IEnumerable<Node> Children { get; set; }
	}
}