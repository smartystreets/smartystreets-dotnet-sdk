namespace SmartyStreets.USZipCodeApi
{
	using System.Collections.Generic;
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
				PopulateQueryString(batch.Get(0), request);
			else
				request.Payload = this.serializer.Serialize(batch.AllLookups);

			var response = this.sender.Send(request);
			var payloadStream = new MemoryStream(response.Payload);

			var results = this.serializer.Deserialize<Result[]>(payloadStream) ?? new Result[0];

			AssignResultsToLookups(batch, results);
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
				batch.Get(i).Result = results[i];
		}
	}
}