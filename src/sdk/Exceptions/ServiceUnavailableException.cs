namespace SmartyStreets
{
	public class ServiceUnavailableException : SmartyException
	{
		public ServiceUnavailableException()
		{
		}

		public ServiceUnavailableException(string message)
			: base(message)
		{
		}
	}
}