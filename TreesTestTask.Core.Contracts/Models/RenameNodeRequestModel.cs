using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TreesTestTask.Core.Contracts.Models
{
	public class RenameNodeRequestModel
	{
		[FromQuery]
		[Required]
		public string TreeName { get; set; }
		[FromQuery]
		[Required]
		public int NodeId { get; set; }
		[FromQuery]
		[Required]
		public string NewNodeName { get; set; }
	}
}