namespace SmartyStreets
{
	public class BadRequestException : SmartyException
	{
		public BadRequestException()
		{
		}

		public BadRequestException(string message)
			: base(message)
		{
		}
	}
}