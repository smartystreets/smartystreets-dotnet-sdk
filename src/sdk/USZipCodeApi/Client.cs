namespace SmartyStreets.USZipCodeApi
{
	using System;
	using System.Collections.Generic;
	using System.IO;
    using System.Threading.Tasks;

    public class Client : IUSZipCodeClient
    {
	    private bool senderWasDisposed;
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}
		
		public void Send(Lookup lookup)
		{
			SendAsync(lookup).GetAwaiter().GetResult();
		}

		public void Send(Batch batch)
		{
			SendAsync(batch).GetAwaiter().GetResult();
		}

		public async Task SendAsync(Lookup lookup)
		{
			if (lookup == null)
				throw new ArgumentNullException("lookup");

			await SendAsync(new Batch { lookup });
		}
		
		/// <summary>
		///     Sends a batch of up to 100 lookups for verification
		/// </summary>
		public async Task SendAsync(Batch batch)
		{
			if (batch == null)
				throw new ArgumentNullException("batch");

			var request = new Request();

			if (batch.Count == 0)
				return;

			if (batch.Count == 1)
				PopulateQueryString(batch[0], request);
			else
			{
				request.ContentType = "application/json";
				request.Payload = batch.Serialize(this.serializer);
			}

			var response = await this.sender.Send(request);

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
			request.SetParameter("compatibility", lookup.Compatibility);

			foreach (KeyValuePair<string, string> line in lookup.CustomParamDict) {
				request.SetParameter(line.Key, line.Value);
			}
		}

		private static void AssignResultsToLookups(Batch batch, IList<Result> results)
		{
			for (var i = 0; i < results.Count; i++)
				batch[i].Result = results[i];
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