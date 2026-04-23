namespace SmartyStreets
{
	public class NotModifiedException : SmartyException
	{
		public string ResponseEtag { get; }

		public NotModifiedException()
		{
		}

		public NotModifiedException(string message)
			: base(message)
		{
		}

		public NotModifiedException(string message, string responseEtag)
			: base(message)
		{
			this.ResponseEtag = responseEtag;
		}
	}
}
