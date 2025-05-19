using System.ComponentModel.DataAnnotations;

namespace TreesTestTask.Dal.Contracts.Entities
{
	public class Node
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		public Guid? ParentId { get; set; }
		public virtual Node? Parent { get; set; }
		
		[Required]
		public Guid TreeId { get; set; }
		public virtual IEnumerable<Node> Childrens { get; set; }
	}
}