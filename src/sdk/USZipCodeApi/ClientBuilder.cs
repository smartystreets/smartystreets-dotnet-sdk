namespace SmartyStreets.USZipCodeApi
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

		public ClientBuilder()
		{
			this.maxRetries = 5;
			this.maxTimeout = TimeSpan.FromSeconds(10);
			this.urlPrefix = "https://us-zipcode.api.smartystreets.com/lookup";
			this.serializer = new NativeSerializer();
		}
		public ClientBuilder(ICredentials signer) : this()
		{
			this.signer = signer;
		}
		public ClientBuilder(string authId, string authToken) : this(new StaticCredentials(authId, authToken))
		{
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

			ISender sender = new NativeSender(this.maxTimeout);

			sender = new StatusCodeSender(sender);

			if (this.signer != null)
				sender = new SigningSender(this.signer, sender);

			if (this.maxRetries > 0)
				sender = new RetrySender(this.maxRetries, sender);

			return sender;
		}
	}
}