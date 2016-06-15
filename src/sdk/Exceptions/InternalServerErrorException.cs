namespace SmartyStreets
{
	public class InternalServerErrorException : SmartyException
	{
		public InternalServerErrorException()
		{
		}

		public InternalServerErrorException(string message)
			: base(message)
		{
		}
	}
}