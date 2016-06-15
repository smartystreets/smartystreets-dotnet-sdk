namespace SmartyStreets
{
	public class PaymentRequiredException : SmartyException
	{
		public PaymentRequiredException()
		{
		}

		public PaymentRequiredException(string message)
			: base(message)
		{
		}
	}
}