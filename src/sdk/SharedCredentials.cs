namespace SmartyStreets
{
	public class SharedCredentials : ICredentials
	{
		private readonly string id;
		private readonly string hostname;

		public SharedCredentials(string id, string hostname)
		{
			this.id = id;
			this.hostname = hostname;
		}

		public void Sign(Request request)
		{
			request.SetParameter("key", this.id);
			request.SetHeader("Referer", "https://" + this.hostname);
		}
	}
}