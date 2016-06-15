namespace SmartyStreets
{
	public class RequestEntityTooLargeException : SmartyException
	{
		public RequestEntityTooLargeException()
		{
		}

		public RequestEntityTooLargeException(string message)
			: base(message)
		{
		}
	}
}