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

		private static bool IsNullOrWhiteSpace(string value)
		{
#if NET35
			if (value == null) return true;
			
			foreach (char c in value)
			{
				if (!char.IsWhiteSpace(c)) return false;
			}

			return true;

#else
 			return string.IsNullOrWhiteSpace(value);
#endif
		}
		private static System.Net.ICredentials ParseCredentials(string username, string password)
		{
			if (IsNullOrWhiteSpace(username) && IsNullOrWhiteSpace(password))
				return CredentialCache.DefaultCredentials;

			return new NetworkCredential(username, password);
		}
	}
}