namespace SmartyStreets
{
	using System;
	using System.Net;

	public class Proxy
	{
		public IWebProxy NativeProxy { get; }

		public Proxy()
		{
		}

		public Proxy(string proxyAddress, string username, string password)
			: this(new Uri(proxyAddress), ParseCredentials(username, password))
		{
		}

		private Proxy(Uri address, System.Net.ICredentials credentials)
		{
			this.NativeProxy = new WebProxy
			{
				Address = address,
				Credentials = credentials
			};
		}

		private static System.Net.ICredentials ParseCredentials(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
				return CredentialCache.DefaultCredentials;

			return new NetworkCredential(username, password);
		}
	}
}