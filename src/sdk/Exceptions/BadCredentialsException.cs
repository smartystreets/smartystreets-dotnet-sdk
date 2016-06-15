namespace SmartyStreets
{
	public class BadCredentialsException : SmartyException
	{
		public BadCredentialsException()
		{
		}

		public BadCredentialsException(string message)
			: base(message)
		{
		}
	}
}