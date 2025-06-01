using System.ComponentModel.DataAnnotations;

namespace TreesTestTask.Core.Contracts.Models
{
	public class RenameNodeRequestModel
	{
		[Required]
		public string? TreeName { get; set; }
		[Required]
		public int NodeId { get; set; }
		[Required]
		public string? NewNodeName { get; set; }
	}
}