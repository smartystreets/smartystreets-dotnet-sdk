namespace SmartyStreets.USEnrichmentApi
{
    using System;

    public class Client : IUSEnrichmentClient
    {
        private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public SmartyStreets.USEnrichmentApi.ResultTypes.Property.Financial.Result[] SendPropertyFinancialLookup(string smartyKey)
		{
			SmartyStreets.USEnrichmentApi.LookupTypes.Property.Financial.Lookup lookup = new SmartyStreets.USEnrichmentApi.LookupTypes.Property.Financial.Lookup(smartyKey);
			Send(lookup);
			return lookup.GetResults();
		}

		public SmartyStreets.USEnrichmentApi.ResultTypes.Property.Principal.Result[] SendPropertyPrincipalLookup(string smartyKey)
		{
			SmartyStreets.USEnrichmentApi.LookupTypes.Property.Principal.Lookup lookup = new SmartyStreets.USEnrichmentApi.LookupTypes.Property.Principal.Lookup(smartyKey);
			Send(lookup);
			return lookup.GetResults();
		}

		private void Send(Lookup lookup)
		{
			if (lookup == null || string.IsNullOrEmpty(lookup.SmartyKey))
				throw new SmartyStreets.SmartyException("Client.Send() requires a Lookup with the 'smartyKey' field set");
			Request request = BuildRequest(lookup);
			Response response = this.sender.Send(request);
			lookup.DeserializeAndSetResults(serializer, response.Payload);
		}

		private SmartyStreets.Request BuildRequest(SmartyStreets.USEnrichmentApi.LookupTypes.Lookup lookup)
		{
			SmartyStreets.Request request = new SmartyStreets.Request();
			request.SetUrlPrefix("/" + lookup.SmartyKey + "/" + lookup.DatasetName + "/" + lookup.DataSubsetName);
			return request;
		}
    }
}