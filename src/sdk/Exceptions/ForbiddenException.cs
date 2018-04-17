namespace SmartyStreets
{
	public class ForbiddenException : SmartyException
	{
		public ForbiddenException()
		{
		}

		public ForbiddenException(string message)
			: base(message)
		{
		}
	}
}