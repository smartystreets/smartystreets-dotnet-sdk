namespace SmartyStreets
{
	using System;

	/// <summary>
	/// The ClientBuilder class helps you build a client object for one of the supported SmartyStreets APIs.
	/// You can use ClientBuilder's methods to customize settings like maximum retries or timeout duration. These methods
	/// are chainable, so you can usually get set up with one line of code.
	/// </summary>
	public class ClientBuilder
	{
		private int maxRetries;
		private TimeSpan maxTimeout;
		private string urlPrefix;
		private readonly ICredentials signer;
		private ISerializer serializer;
		private ISender httpSender;
		private string INTERNATIONAL_STREET_API_URL = "https://international-street.api.smartystreets.com/verify";
		private string US_AUTOCOMPLETE_API_URL = "https://us-autocomplete.api.smartystreets.com/suggest";
		private string US_EXTRACT_API_URL = "https://us-extract.api.smartystreets.com/";
		private string US_STREET_API_URL = "https://us-street.api.smartystreets.com/street-address";
		private string US_ZIP_CODE_API_URL = "https://us-zipcode.api.smartystreets.com/lookup";

		public ClientBuilder()
		{
			this.maxRetries = 5;
			this.maxTimeout = TimeSpan.FromSeconds(10);
			this.serializer = new NativeSerializer();
		}
		public ClientBuilder(ICredentials signer) : this()
		{
			this.signer = signer;
		}
		public ClientBuilder(string authId, string authToken) : this(new StaticCredentials(authId, authToken))
		{
		}

		/// <param name="retries">The maximum number of times to retry sending the request to the API. (Default is 5)</param>
		/// <returns>Returns 'this' to accommodate method chaining.</returns>
		public ClientBuilder RetryAtMost(int retries)
		{
			this.maxRetries = retries;
			return this;
		}

		/// <param name="timeout">
		/// The maximum time (given as a TimeSpan) to wait for a connection, and also to wait for
		/// the response to be read. (Default is 10 seconds)
		/// </param>
		/// <returns>Returns 'this' to accommodate method chaining.</returns>
		public ClientBuilder WithMaxTimeout(TimeSpan timeout)
		{
			this.maxTimeout = timeout;
			return this;
		}

		///<remarks>This may be useful when using a local installation of the SmartyStreets APIs.</remarks>
		/// <param name="baseUrl">Defaults to the URL for the API corresponding to the Client object being built.</param>
		/// <returns>Returns 'this' to accommodate method chaining.</returns>
		public ClientBuilder WithCustomBaseUrl(string baseUrl)
		{
			this.urlPrefix = baseUrl;
			return this;
		}

		/// <summary>
		/// Changes the Serializer from the default NativeSerializer.
		/// </summary>
		/// <param name="value">An object that implements the ISerializer interface.</param>
		/// <returns>Returns 'this' to accommodate method chaining.</returns>
		public ClientBuilder WithSerializer(ISerializer value)
		{
			this.serializer = value;
			return this;
		}

		/// <param name="sender">Default is a series of nested senders. See BuildSender().</param>
		/// <returns>Returns 'this' to accommodate method chaining.</returns>
		public ClientBuilder WithSender(ISender sender)
		{
			this.httpSender = sender;
			return this;
		}

//		public InternationalStreetApi.Client BuildInternationalStreetAPIClient() {
//			EnsureURLPrefixNotNull(this.INTERNATIONAL_STREET_API_URL);
//			return new InternationalStreetApi.Client(BuildSender(), this.serializer);
//		}

//		public USAutocompleteApi.Client BuildUSAutocompleteAPIClient() {
//			EnsureURLPrefixNotNull(this.US_AUTOCOMPLETE_API_URL);
//			return new USAutocompleteApi.Client(BuildSender(), this.serializer);
//		}

		public USExtractApi.Client BuildUSExtractAPIClient() {
			this.EnsureURLPrefixNotNull(this.US_EXTRACT_API_URL);
			return new USExtractApi.Client(BuildSender(), this.serializer);
		}

		public USStreetApi.Client BuildUSStreetAPIClient()
		{
			EnsureURLPrefixNotNull(this.US_STREET_API_URL);
			return new USStreetApi.Client(this.BuildSender(), this.serializer);
		}

		public USZipCodeApi.Client BuildUSZipCodeAPIClient()
		{
			EnsureURLPrefixNotNull(this.US_ZIP_CODE_API_URL);
			return new USZipCodeApi.Client(this.BuildSender(), this.serializer);
		}

		private ISender BuildSender()
		{
			if (this.httpSender != null)
				return this.httpSender;

			ISender sender = new NativeSender(this.maxTimeout);
			sender = new StatusCodeSender(sender);

			if (this.signer != null)
				sender = new SigningSender(this.signer, sender);

			sender = new URLPrefixSender(this.urlPrefix, sender);

			if (this.maxRetries > 0)
				sender = new RetrySender(this.maxRetries, sender);

			return sender;
		}

		private void EnsureURLPrefixNotNull(string url)
		{
			if (this.urlPrefix == null)
				this.urlPrefix = url;
		}
	}
}