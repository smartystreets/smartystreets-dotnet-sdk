namespace SmartyStreets
{
	public class NotModifiedException : SmartyException
	{
		public NotModifiedException()
		{
		}

		public NotModifiedException(string message)
			: base(message)
		{
		}
	}
}