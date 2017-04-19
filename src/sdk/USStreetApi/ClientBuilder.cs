using System.Net;

namespace SmartyStreets.USStreetApi
{
	using System;

	public class ClientBuilder
	{
		private int maxRetries;
		private TimeSpan maxTimeout;
		private string urlPrefix;
		private readonly ICredentials signer;
		private ISerializer serializer;
		private ISender httpSender;
	    private WebProxy webProxy;
		public ClientBuilder()
		{
			this.maxRetries = 5;
			this.maxTimeout = TimeSpan.FromSeconds(10);
			this.urlPrefix = "https://us-street.api.smartystreets.com/street-address";
			this.serializer = new StandardLibraryJsonSerializer();
		}
		public ClientBuilder(ICredentials signer) : this()
		{
			this.signer = signer;
		}
		public ClientBuilder(string authId, string authToken, WebProxy proxy = null) : this(new StaticCredentials(authId, authToken))
		{
		    webProxy = proxy;

		}

		public ClientBuilder RetryAtMost(int retries)
		{
			this.maxRetries = retries;
			return this;
		}
		public ClientBuilder WithMaxTimeout(TimeSpan timeout)
		{
			this.maxTimeout = timeout;
			return this;
		}
		public ClientBuilder WithUrl(string prefix)
		{
			this.urlPrefix = prefix;
			return this;
		}
		public ClientBuilder WithSerializer(ISerializer value)
		{
			this.serializer = value;
			return this;
		}
		public ClientBuilder WithSender(ISender sender)
		{
			this.httpSender = sender;
			return this;
		}

		public Client Build()
		{
			return new Client(this.urlPrefix, this.BuildSender(), this.serializer);
		}
		private ISender BuildSender()
		{
			if (this.httpSender != null)
				return this.httpSender;

			ISender sender = new StandardLibrarySender(this.maxTimeout, webProxy);
			sender = new StatusCodeSender(sender);

			if (this.signer != null)
				sender = new SigningSender(this.signer, sender);

			if (this.maxRetries > 0)
				sender = new RetrySender(this.maxRetries, sender);

			return sender;
		}
	}
}