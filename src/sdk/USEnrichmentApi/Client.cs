namespace SmartyStreets.USEnrichmentApi
{
    using System;
	using System.IO;
	using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Client : IDisposable //: IUSEnrichmentClient 
    {
	    private bool senderWasDisposed;
        private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public async Task<Property.Financial.Result[]> SendPropertyFinancialLookup(string smartyKey)
		{
			Property.Financial.Lookup lookup = new Property.Financial.Lookup(smartyKey);
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<Property.Financial.Result[]> SendPropertyFinancialLookup(Property.Financial.Lookup lookup)
		{
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<Property.Principal.Result[]> SendPropertyPrincipalLookup(string smartyKey)
		{
			Property.Principal.Lookup lookup = new Property.Principal.Lookup(smartyKey);
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<Property.Principal.Result[]> SendPropertyPrincipalLookup(Property.Principal.Lookup lookup)
		{
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<GeoReference.Result[]> SendGeoReferenceLookup(string smartyKey)
		{
			GeoReference.Lookup lookup = new GeoReference.Lookup(smartyKey);
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<GeoReference.Result[]> SendGeoReferenceLookup(GeoReference.Lookup lookup)
		{
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<Secondary.Result[]> SendSecondaryLookup(string smartyKey)
		{
			Secondary.Lookup lookup = new Secondary.Lookup(smartyKey);
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<Secondary.Result[]> SendSecondaryLookup(Secondary.Lookup lookup)
		{
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<Secondary.Count.Result[]> SendSecondaryCountLookup(string smartyKey)
		{
			Secondary.Count.Lookup lookup = new Secondary.Count.Lookup(smartyKey);
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<Secondary.Count.Result[]> SendSecondaryCountLookup(Secondary.Count.Lookup lookup)
		{
			await Send(lookup);
			return lookup.GetResults();
		}

		public async Task<byte[]> SendUniversalLookup(Universal.Lookup lookup)
		{
			await Send(lookup);
			return lookup.GetResults();
		}

		private async Task Send(Lookup lookup)
		{
			if (lookup == null || (string.IsNullOrEmpty(lookup.GetSmartyKey()) && string.IsNullOrEmpty(lookup.GetStreet()) && string.IsNullOrEmpty(lookup.GetFreeform())))
				throw new SmartyStreets.SmartyException("Client.Send() requires a Lookup with the 'smartyKey', 'street', or 'freeform' field set");
			Request request = BuildRequest(lookup);
			Response response = await this.sender.Send(request);
			foreach(var entry in response.HeaderInfo) {
				if (entry.Key == "Etag") {
					lookup.SetEtag(entry.Value);
				}
			}
			if (response.Payload != null){
				using (var payloadStream = new MemoryStream(response.Payload)){
					if (serializer == null) {
						Console.WriteLine("true");
					}
					lookup.DeserializeAndSetResults(serializer, payloadStream);
				}
			}
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

			if (lookup.GetIncludeFields() != null) {
				request.SetParameter("include", lookup.GetIncludeFields());
			}
			if (lookup.GetExcludeFields() != null) {
				request.SetParameter("exclude", lookup.GetExcludeFields());
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
			if (lookup.GetEtag() != null) {
				request.SetHeader("Etag", lookup.GetEtag());
			}

			foreach (KeyValuePair<string, string> line in lookup.CustomParamDict) {
				request.SetParameter(line.Key, line.Value);
			}

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