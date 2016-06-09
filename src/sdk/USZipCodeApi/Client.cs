using System.IO;

namespace SmartyStreets.USZipCodeApi
{
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
			var batch = new Batch();
			batch.Add(lookup);
			this.Send(batch);
		}

		public void Send(Batch batch)
		{
			var request = new Request(this.urlPrefix);

			if (batch.Size() == 0)
				return;

			if (batch.Size() == 1)
				this.PopulateQueryString(batch.Get(0), request);
			else
				request.Payload = this.serializer.Serialize(batch.AllLookups);

			var response = sender.Send(request);
			var payloadStream = new MemoryStream(response.Payload);

			Result[] results = this.serializer.Deserialize<Result[]>(payloadStream);
			if (results == null)
				results = new Result[0];
			this.AssignResultsToLookups(batch, results);
		}

		private void PopulateQueryString(Lookup lookup, Request request)
		{
			request.AddParameter("input_id", lookup.InputId);
			request.AddParameter("city", lookup.City);
			request.AddParameter("state", lookup.State);
			request.AddParameter("zipcode", lookup.ZipCode);
		}

		private void AssignResultsToLookups(Batch batch, Result[] results)
		{
			for (int i = 0; i < results.Length; i++)
				batch.Get(i).Result = results[i];
		}
	}
}

