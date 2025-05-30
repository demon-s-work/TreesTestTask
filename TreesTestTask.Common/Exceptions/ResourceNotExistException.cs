using Microsoft.AspNetCore.Http;

namespace TreesTestTask.Common.Exceptions
{
	public class ResourceNotExistException : BaseException
	{
		public override int ResponseStatusCode => StatusCodes.Status404NotFound;
		private const string ExceptionMessage = "Such {0} does not exist";

		public ResourceNotExistException(string resourceName) : base(string.Format(ExceptionMessage, resourceName))
		{
		}
	}
}