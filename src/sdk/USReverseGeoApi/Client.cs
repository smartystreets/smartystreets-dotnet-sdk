namespace SmartyStreets.USReverseGeoApi
{
	using System;
	using System.IO;
	using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Client : IUSReverseGeoClient
    {
	    private bool senderWasDisposed; 
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public async Task Send(Lookup lookup)
		{
			if (lookup == null)
				throw new ArgumentNullException("lookup");

			var request = BuildRequest(lookup);

			var response = await this.sender.Send(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var smartyResponse = this.serializer.Deserialize<SmartyResponse>(payloadStream) ?? new SmartyResponse();
				lookup.SmartyResponse = smartyResponse;
			}
		}

		private static Request BuildRequest(Lookup lookup)
		{
			var request = new Request();

			request.SetParameter("latitude", lookup.Latitude);
			request.SetParameter("longitude", lookup.Longitude);
			request.SetParameter("source", lookup.Source);

			foreach (KeyValuePair<string, string> line in lookup.CustomParamDict) {
				request.SetParameter(line.Key, line.Value);
			}

			return request;
		}

		public void Dispose()
		{
			if (!senderWasDisposed)
			{
				sender.Dispose();
				senderWasDisposed = true;
			}
		}
	}
}