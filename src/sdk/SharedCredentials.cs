using System;
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
			throw new NotImplementedException();
		}
	}
}

