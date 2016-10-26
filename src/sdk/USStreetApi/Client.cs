using System.Threading.Tasks;

namespace SmartyStreets.USStreetApi
{
	using System.Globalization;
	using System.IO;

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
	            var candidates = this.serializer.Deserialize<Candidate[]>(payloadStream) ?? new Candidate[0];
	            AssignCandidatesToLookups(batch, candidates);
	        }
	    }

	    private Request CreateRequest(Batch batch)
	    {
	        var request = new Request(this.urlPrefix);

	        PutHeaders(batch, request);

	        if (batch.Count == 1)
	            PopulateQueryString(batch[0], request);
	        else
	            request.Payload = batch.Serialize(this.serializer);
	        return request;
	    }

	    private static void PutHeaders(Batch batch, Request request)
		{
			if (batch.IncludeInvalid)
				request.SetHeader("X-Include-Invalid", "true");
			else if (batch.StandardizeOnly)
				request.SetHeader("X-Standardize-Only", "true");
		}

		private static void PopulateQueryString(Lookup address, Request request)
		{
			request.SetParameter("street", address.Street);
			request.SetParameter("street2", address.Street2);
			request.SetParameter("secondary", address.Secondary);
			request.SetParameter("city", address.City);
			request.SetParameter("state", address.State);
			request.SetParameter("zipcode", address.ZipCode);
			request.SetParameter("lastline", address.Lastline);
			request.SetParameter("addressee", address.Addressee);
			request.SetParameter("urbanization", address.Urbanization);

			if (address.MaxCandidates != 1)
				request.SetParameter("candidates", address.MaxCandidates.ToString(CultureInfo.InvariantCulture));
		}

		private static void AssignCandidatesToLookups(Batch batch, Candidate[] candidates)
		{
			foreach (var candidate in candidates)
				batch[candidate.InputIndex].AddToResult(candidate);
		}
	}
}