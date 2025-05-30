using Microsoft.AspNetCore.Http;

namespace TreesTestTask.Common.Exceptions
{
	public abstract class BaseException : Exception
	{
		public virtual int ResponseStatusCode => StatusCodes.Status500InternalServerError;

		protected BaseException(string message) : base(message)
		{

		}
	}
}