namespace SmartyStreets.USZipCodeApi
{
	using System.Collections.Generic;
	using System.IO;
    using System.Threading.Tasks;

    public class Client
	{
		private readonly string urlPrefix;
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(string urlPrefix, ISender sender, ISerializer serializer)
		{
			this.urlPrefix = urlPrefix;
			this.sender = sender;
			this.serializer = serializer;
		}

		public void Send(Lookup lookup)
		{
		    var batch = new Batch {lookup};
		    this.Send(batch);
        }

        public Task SendAsync(Lookup lookup)
        {
            var batch = new Batch {lookup};
            return this.SendAsync(batch);
        }

        public void Send(Batch batch)
        {
            if (batch.Count == 0)
                return;

            var request = CreateRequest(batch);

            var response = this.sender.Send(request);

            HandleResponse(batch, response);
        }

        public async Task SendAsync(Batch batch)
        {
            if (batch.Count == 0)
                return;

            var request = CreateRequest(batch);

            var response = await this.sender.SendAsync(request).ConfigureAwait(false);

            HandleResponse(batch, response);
        }

	    private void HandleResponse(Batch batch, Response response)
	    {
	        using (var payloadStream = new MemoryStream(response.Payload))
	        {
	            var results = this.serializer.Deserialize<Result[]>(payloadStream) ?? new Result[0];
	            AssignResultsToLookups(batch, results);
	        }
	    }

	    private Request CreateRequest(Batch batch)
	    {
	        var request = new Request(this.urlPrefix);

	        if (batch.Count == 1)
	            PopulateQueryString(batch[0], request);
	        else
	            request.Payload = batch.Serialize(this.serializer);
	        return request;
	    }

	    private static void PopulateQueryString(Lookup lookup, Request request)
		{
			request.SetParameter("input_id", lookup.InputId);
			request.SetParameter("city", lookup.City);
			request.SetParameter("state", lookup.State);
			request.SetParameter("zipcode", lookup.ZipCode);
		}
		private static void AssignResultsToLookups(Batch batch, IList<Result> results)
		{
			for (var i = 0; i < results.Count; i++)
				batch[i].Result = results[i];
		}
	}
}