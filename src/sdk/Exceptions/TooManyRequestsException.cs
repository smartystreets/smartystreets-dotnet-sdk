namespace SmartyStreets
{
	public class TooManyRequestsException : SmartyException
	{
		public TooManyRequestsException()
		{
		}

		public TooManyRequestsException(string message)
			: base(message)
		{
		}
	}
}