using System.ComponentModel.DataAnnotations;

namespace TreesTestTask.Core.Contracts.Models
{
	public class CreateNodeRequestModel
	{
		[Required]
		public string? TreeName { get; set; }

		[Required]
		public int ParentNodeId { get; set; }

		[Required]
		public string? NodeName { get; set; }
	}
}