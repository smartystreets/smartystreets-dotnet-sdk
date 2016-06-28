namespace SmartyStreets
{
	public class SharedCredentials : ICredentials
	{
		private string id;
		private string hostname;

		public SharedCredentials(string id, string hostname)
		{
			this.id = id;
			this.hostname = hostname;
		}

		public void Sign(Request request)
		{
			request.SetParameter("auth-id", this.id);
			request.SetHeader("Referer", "https://" + this.hostname);
		}
	}
}

