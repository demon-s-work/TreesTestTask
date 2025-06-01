using System.ComponentModel.DataAnnotations;

namespace TreesTestTask.Core.Contracts.Models
{
	public class DeleteNodeRequestModel
	{
		[Required]
		public string TreeName { get; set; }
		[Required]
		public int NodeId { get; set; }
	}
}