namespace SmartyStreets.USEnrichmentApi
{
    using System;
	using System.IO;

    public class Client //: IUSEnrichmentClient
    {
        private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public Property.Financial.Result[] SendPropertyFinancialLookup(string smartyKey)
		{
			Property.Financial.Lookup lookup = new Property.Financial.Lookup(smartyKey);
			Send(lookup);
			return lookup.GetResults();
		}

		public Property.Principal.Result[] SendPropertyPrincipalLookup(string smartyKey)
		{
			Property.Principal.Lookup lookup = new Property.Principal.Lookup(smartyKey);
			Send(lookup);
			return lookup.GetResults();
		}

		private void Send(Lookup lookup)
		{
			if (lookup == null || string.IsNullOrEmpty(lookup.GetSmartyKey()))
				throw new SmartyStreets.SmartyException("Client.Send() requires a Lookup with the 'smartyKey' field set");
			Request request = BuildRequest(lookup);
			Response response = this.sender.Send(request);
			if (response.Payload != null){
				using (var payloadStream = new MemoryStream(response.Payload)){
					lookup.DeserializeAndSetResults(serializer, payloadStream);
				}
			}
		}

		private SmartyStreets.Request BuildRequest(Lookup lookup)
		{
			SmartyStreets.Request request = new SmartyStreets.Request();
			request.SetUrlPrefix("/" + lookup.GetSmartyKey() + "/" + lookup.GetDatasetName() + "/" + lookup.GetDataSubsetName());
			return request;
		}
    }
}