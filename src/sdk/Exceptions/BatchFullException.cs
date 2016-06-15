namespace SmartyStreets
{
	public class BatchFullException : SmartyException
	{
		public BatchFullException()
		{
		}

		public BatchFullException(string message)
			: base(message)
		{
		}
	}
}