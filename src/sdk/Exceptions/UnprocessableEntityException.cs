namespace SmartyStreets
{
	public class UnprocessableEntityException : SmartyException
	{
		public UnprocessableEntityException()
		{
		}

		public UnprocessableEntityException(string message)
			: base(message)
		{
		}
	}
}