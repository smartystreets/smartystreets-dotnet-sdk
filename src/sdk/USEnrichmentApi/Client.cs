namespace SmartyStreets.USEnrichmentApi
{
    using System;
	using System.IO;
	using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Client : IDisposable //, IUSEnrichmentClient 
    {
	    private bool senderWasDisposed;
        private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public Property.Principal.Result[] SendPropertyPrincipalLookup(string smartyKey)
		{
			return SendPropertyPrincipalLookupAsync(smartyKey).GetAwaiter().GetResult();
		}

		public async Task<Property.Principal.Result[]> SendPropertyPrincipalLookupAsync(string smartyKey)
		{
			Property.Principal.Lookup lookup = new Property.Principal.Lookup(smartyKey);
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public Property.Principal.Result[] SendPropertyPrincipalLookup(Property.Principal.Lookup lookup)
		{
			return SendPropertyPrincipalLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<Property.Principal.Result[]> SendPropertyPrincipalLookupAsync(Property.Principal.Lookup lookup)
		{
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public GeoReference.Result[] SendGeoReferenceLookup(string smartyKey)
		{
			return SendGeoReferenceLookupAsync(smartyKey).GetAwaiter().GetResult();
		}

		public async Task<GeoReference.Result[]> SendGeoReferenceLookupAsync(string smartyKey)
		{
			GeoReference.Lookup lookup = new GeoReference.Lookup(smartyKey);
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public GeoReference.Result[] SendGeoReferenceLookup(GeoReference.Lookup lookup)
		{
			return SendGeoReferenceLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<GeoReference.Result[]> SendGeoReferenceLookupAsync(GeoReference.Lookup lookup)
		{
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public Risk.Result[] SendRiskLookup(string smartyKey)
		{
			return SendRiskLookupAsync(smartyKey).GetAwaiter().GetResult();
		}

		public async Task<Risk.Result[]> SendRiskLookupAsync(string smartyKey)
		{
			Risk.Lookup lookup = new Risk.Lookup(smartyKey);
			await SendAsync(lookup);
			return lookup.GetResults();
		}

		public Risk.Result[] SendRiskLookup(Risk.Lookup lookup)
		{
			return SendRiskLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<Risk.Result[]> SendRiskLookupAsync(Risk.Lookup lookup)
		{
			await SendAsync(lookup);
			return lookup.GetResults();
		}

		public Secondary.Result[] SendSecondaryLookup(string smartyKey)
		{
			return SendSecondaryLookupAsync(smartyKey).GetAwaiter().GetResult();
		}

		public async Task<Secondary.Result[]> SendSecondaryLookupAsync(string smartyKey)
		{
			Secondary.Lookup lookup = new Secondary.Lookup(smartyKey);
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public Secondary.Result[] SendSecondaryLookup(Secondary.Lookup lookup)
		{
			return SendSecondaryLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<Secondary.Result[]> SendSecondaryLookupAsync(Secondary.Lookup lookup)
		{
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public Secondary.Count.Result[] SendSecondaryCountLookup(string smartyKey)
		{
			return SendSecondaryCountLookupAsync(smartyKey).GetAwaiter().GetResult();
		}

		public async Task<Secondary.Count.Result[]> SendSecondaryCountLookupAsync(string smartyKey)
		{
			Secondary.Count.Lookup lookup = new Secondary.Count.Lookup(smartyKey);
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public Secondary.Count.Result[] SendSecondaryCountLookup(Secondary.Count.Lookup lookup)
		{
			return SendSecondaryCountLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<Secondary.Count.Result[]> SendSecondaryCountLookupAsync(Secondary.Count.Lookup lookup)
		{
			await SendAsync(lookup);
			return lookup.GetResults();
		}
		
		public byte[] SendUniversalLookup(Universal.Lookup lookup)
		{
			return  SendUniversalLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<byte[]> SendUniversalLookupAsync(Universal.Lookup lookup)
		{
			await SendAsync(lookup);
			return lookup.GetResults();
		}

		public Business.Summary.Result[] SendBusinessLookup(string smartyKey)
		{
			return SendBusinessLookupAsync(smartyKey).GetAwaiter().GetResult();
		}

		public async Task<Business.Summary.Result[]> SendBusinessLookupAsync(string smartyKey)
		{
			Business.Summary.Lookup lookup = new Business.Summary.Lookup(smartyKey);
			await SendAsync(lookup);
			return lookup.GetResults();
		}

		public Business.Summary.Result[] SendBusinessLookup(Business.Summary.Lookup lookup)
		{
			return SendBusinessLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<Business.Summary.Result[]> SendBusinessLookupAsync(Business.Summary.Lookup lookup)
		{
			await SendAsync(lookup);
			return lookup.GetResults();
		}

		public Business.Detail.Result SendBusinessDetailLookup(string businessId)
		{
			return SendBusinessDetailLookupAsync(businessId).GetAwaiter().GetResult();
		}

		public async Task<Business.Detail.Result> SendBusinessDetailLookupAsync(string businessId)
		{
			Business.Detail.Lookup lookup = new Business.Detail.Lookup(businessId);
			await SendBusinessDetailAsync(lookup);
			return lookup.GetResult();
		}

		public Business.Detail.Result SendBusinessDetailLookup(Business.Detail.Lookup lookup)
		{
			return SendBusinessDetailLookupAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task<Business.Detail.Result> SendBusinessDetailLookupAsync(Business.Detail.Lookup lookup)
		{
			await SendBusinessDetailAsync(lookup);
			return lookup.GetResult();
		}

		private async Task SendBusinessDetailAsync(Business.Detail.Lookup lookup)
		{
			if (lookup == null || string.IsNullOrWhiteSpace(lookup.GetBusinessId()))
				throw new SmartyStreets.SmartyException("Business.Detail.Lookup requires a non-empty 'businessId'");

			Request request = new Request();
			request.SetUrlComponents("/business/" + Uri.EscapeDataString(lookup.GetBusinessId()));
			ApplyCommonRequestFields(request, lookup);

			await DispatchAsync(request, lookup);
		}

		private async Task SendAsync(Lookup lookup)
		{
			if (lookup == null || (string.IsNullOrWhiteSpace(lookup.GetSmartyKey()) && string.IsNullOrWhiteSpace(lookup.GetStreet()) && string.IsNullOrWhiteSpace(lookup.GetFreeform())))
				throw new SmartyStreets.SmartyException("Lookup requires one of 'smartyKey', 'street', or 'freeform' to be set");
			Request request = BuildRequest(lookup);
			await DispatchAsync(request, lookup);
		}

		private async Task DispatchAsync(Request request, EnrichmentLookupBase lookup)
		{
			Response response = await this.sender.SendAsync(request);
			if (response.HeaderInfo != null)
			{
				foreach (var entry in response.HeaderInfo)
				{
					if (string.Equals(entry.Key, "Etag", StringComparison.OrdinalIgnoreCase))
						lookup.SetResponseEtag(entry.Value);
				}
			}
			if (response.Payload != null)
			{
				using (var payloadStream = new MemoryStream(response.Payload))
				{
					lookup.DeserializeAndSetResults(serializer, payloadStream);
				}
			}
		}

		private static void ApplyCommonRequestFields(Request request, EnrichmentLookupBase lookup)
		{
			if (lookup.GetIncludeFields() != null)
				request.SetParameter("include", lookup.GetIncludeFields());
			if (lookup.GetExcludeFields() != null)
				request.SetParameter("exclude", lookup.GetExcludeFields());
			if (lookup.GetRequestEtag() != null)
				request.SetHeader("Etag", lookup.GetRequestEtag());
			foreach (KeyValuePair<string, string> line in lookup.GetCustomParameters())
				request.SetParameter(line.Key, line.Value);
		}

		private SmartyStreets.Request BuildRequest(Lookup lookup)
		{
			SmartyStreets.Request request = new SmartyStreets.Request();

			// some datasets have no data subset
			if (string.IsNullOrEmpty(lookup.GetSmartyKey())) {
				if (lookup.GetDataSubsetName() == "") {
				request.SetUrlComponents("/search/" + lookup.GetDatasetName());
				} else {
				request.SetUrlComponents("/search/" + lookup.GetDatasetName() + "/" + lookup.GetDataSubsetName());
				}
			} else {
				if (lookup.GetDataSubsetName() == "") {
				request.SetUrlComponents("/" + lookup.GetSmartyKey() + "/" + lookup.GetDatasetName());
				} else {
				request.SetUrlComponents("/" + lookup.GetSmartyKey() + "/" + lookup.GetDatasetName() + "/" + lookup.GetDataSubsetName());
				}
			}

			if (lookup.GetFeatures() != null) {
				request.SetParameter("features", lookup.GetFeatures());
			}
			if (lookup.GetFreeform() != null) {
				request.SetParameter("freeform", lookup.GetFreeform());
			}
			if (lookup.GetStreet() != null) {
				request.SetParameter("street", lookup.GetStreet());
			}
			if (lookup.GetCity() != null) {
				request.SetParameter("city", lookup.GetCity());
			}
			if (lookup.GetState() != null) {
				request.SetParameter("state", lookup.GetState());
			}
			if (lookup.GetZipcode() != null) {
				request.SetParameter("zipcode", lookup.GetZipcode());
			}

			ApplyCommonRequestFields(request, lookup);

			return request;
		}

		public void Dispose()
		{
			if (!this.senderWasDisposed)
			{
				this.sender.Dispose();
				senderWasDisposed = true;
			}
		}
    }
}