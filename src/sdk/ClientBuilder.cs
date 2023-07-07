using System.Collections.Generic;

namespace SmartyStreets
{
    using System;

    /// <summary>
    ///     The ClientBuilder class helps you build a client object for one of the supported SmartyStreets APIs.
    ///     You can use ClientBuilder's methods to customize settings like maximum retries or timeout duration. These methods
    ///     are chainable, so you can usually get set up with one line of code.
    ///     THREAD SAFETY: Instances of the ClientBuilder class are NOT thread safe and are only designed to be called from
    ///     a single thread. Typically the Build() method should be called and then the ClientBuilder instance should be
    ///     discarded.
    /// </summary>
    public class ClientBuilder
    {
        private int maxRetries;
        private TimeSpan maxTimeout;
        private string urlPrefix;
        private readonly ICredentials signer;
        private ISerializer serializer;
        private ISender httpSender;
        private Proxy proxy;
        private Dictionary<string, string> customHeaders;
        private List<string> licenses;
        private const string InternationalStreetApiUrl = "https://international-street.api.smarty.com/verify";
        private const string InternationalAutocompleteApiUrl = "https://international-autocomplete.api.smarty.com/lookup";
        private const string UsAutocompleteApiUrl = "https://us-autocomplete.api.smarty.com/suggest";
        private const string UsAutocompleteProApiUrl = "https://us-autocomplete-pro.api.smarty.com/lookup";
        private const string UsExtractApiUrl = "https://us-extract.api.smarty.com/";
        private const string UsStreetApiUrl = "https://us-street.api.smarty.com/street-address";
        private const string UsZipCodeApiUrl = "https://us-zipcode.api.smarty.com/lookup";
        private const string UsReverseGeoApiUrl = "https://us-reverse-geo.api.smarty.com/lookup";

        public ClientBuilder()
        {
            this.maxRetries = 5;
            this.maxTimeout = TimeSpan.FromSeconds(10);
            this.serializer = new NativeSerializer();
            this.licenses = new List<string>();
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
        ///     The maximum time (given as a TimeSpan) to wait for a connection, and also to wait for
        ///     the response to be read. (Default is 10 seconds)
        /// </param>
        /// <returns>Returns 'this' to accommodate method chaining.</returns>
        public ClientBuilder WithMaxTimeout(TimeSpan timeout)
        {
            this.maxTimeout = timeout;
            return this;
        }

        /// <remarks>This may be useful when using a local installation of the SmartyStreets APIs.</remarks>
        /// <param name="baseUrl">Defaults to the URL for the API corresponding to the Client object being built.</param>
        /// <returns>Returns 'this' to accommodate method chaining.</returns>
        public ClientBuilder WithCustomBaseUrl(string baseUrl)
        {
            this.urlPrefix = baseUrl;
            return this;
        }
        
        /// <remarks>Use this to add any additional headers you need.</remarks>
        /// <param name="headers">A Dictionary<string, string> of header name/value pairs.</param>
        /// <returns>Returns 'this' to accommodate method chaining.</returns>
        public ClientBuilder WithCustomHeaders(Dictionary<string, string> headers)
        {
            this.customHeaders = headers;
            return this;
        }

        /// <remarks>ViaProxy saves the address of your proxy server through which to send all requests.</remarks>
        /// <param name="proxyAddress">Proxy address of your proxy server</param>
        /// <param name="proxyUsername">Username for proxy authentication</param>
        /// <param name="proxyPassword">Password for proxy authentication</param>
        /// <returns>Returns 'this' to accommodate method chaining.</returns>
        public ClientBuilder ViaProxy(string proxyAddress, string proxyUsername, string proxyPassword)
        {
            if (proxyAddress == null)
                throw new UnprocessableEntityException("ProxyUrl is required");

            this.proxy = new Proxy(proxyAddress, proxyUsername, proxyPassword);
            return this;
        }

        /// <summary>
        ///     Changes the Serializer from the default NativeSerializer.
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

        /// <summary>
        ///     Allows the caller to specify the subscription license(s) (aka "track") they wish to use.
        /// </summary>
        /// <param name="licenses">A List of license strings</param>
        /// <returns>Returns 'this' to accommodate method chaining.</returns>
        public ClientBuilder WithLicense(List<string> licenses)
        {
            this.licenses.AddRange(licenses);
            return this;
        }

        public InternationalStreetApi.Client BuildInternationalStreetApiClient()
        {
            this.EnsureURLPrefixNotNull(InternationalStreetApiUrl);
            return new InternationalStreetApi.Client(this.BuildSender(), this.serializer);
        }
        
public InternationalAutocompleteApi.Client BuildInternationalAutocompleteApiClient()
        {
            this.EnsureURLPrefixNotNull(InternationalAutocompleteApiUrl);
            return new InternationalAutocompleteApi.Client(this.BuildSender(), this.serializer);
        }

        public USAutocompleteApi.Client BuildUsAutocompleteApiClient()
        {
            this.EnsureURLPrefixNotNull(UsAutocompleteApiUrl);
            return new USAutocompleteApi.Client(this.BuildSender(), this.serializer);
        }

        public USAutocompleteProApi.Client BuildUsAutocompleteProApiClient()
        {
            this.EnsureURLPrefixNotNull(UsAutocompleteProApiUrl);
            return new USAutocompleteProApi.Client(this.BuildSender(), this.serializer);
        }

        public USExtractApi.Client BuildUsExtractApiClient()
        {
            this.EnsureURLPrefixNotNull(UsExtractApiUrl);
            return new USExtractApi.Client(this.BuildSender(), this.serializer);
        }

        public USStreetApi.Client BuildUsStreetApiClient()
        {
            this.EnsureURLPrefixNotNull(UsStreetApiUrl);
            return new USStreetApi.Client(this.BuildSender(), this.serializer);
        }

        public USZipCodeApi.Client BuildUsZipCodeApiClient()
        {
            this.EnsureURLPrefixNotNull(UsZipCodeApiUrl);
            return new USZipCodeApi.Client(this.BuildSender(), this.serializer);
        }

        public USReverseGeoApi.Client BuildUsReverseGeoApiClient()
        {
            this.EnsureURLPrefixNotNull(UsReverseGeoApiUrl);
            return new USReverseGeoApi.Client(this.BuildSender(), this.serializer);
        }

        private ISender BuildSender()
        {
            if (this.httpSender != null)
                return this.httpSender;

            ISender sender = new NativeSender(this.maxTimeout, this.proxy);
            sender = new StatusCodeSender(sender);
            
            if (this.customHeaders != null)
                sender = new CustomHeaderSender(this.customHeaders, sender);

            if (this.signer != null)
                sender = new SigningSender(this.signer, sender);

            sender = new URLPrefixSender(this.urlPrefix, sender);

            if (this.maxRetries > 0)
                sender = new RetrySender(this.maxRetries, sender, this.Sleep, new RandomGenerator());
            
            sender = new LicenseSender(this.licenses, sender);

            return sender;
        }

        private void Sleep(int time)
        {
            System.Threading.Thread.Sleep(time);
        }

        private void EnsureURLPrefixNotNull(string url)
        {
            if (this.urlPrefix == null)
                this.urlPrefix = url;
        }
    }
}