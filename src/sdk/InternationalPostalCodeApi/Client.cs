namespace SmartyStreets.InternationalPostalCodeApi
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Threading.Tasks;

	/// <summary>
	///     This client sends lookups to the SmartyStreets International Postal Code API,
	///     and attaches the results to the appropriate Lookup objects.
	/// </summary>
	public class Client : IInternationalPostalCodeClient
	{
		private bool senderIsDisposed;
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

		public async Task SendAsync(Lookup lookup)
		{
			if (lookup == null)
				throw new ArgumentNullException("lookup");

			var request = BuildRequest(lookup);

			var response = await this.sender.SendAsync(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var candidates = this.serializer.Deserialize<List<Candidate>>(payloadStream) ?? new List<Candidate>();
				AssignCandidatesToLookups(candidates, lookup);
			}
		}

		private static void AssignCandidatesToLookups(IEnumerable<Candidate> candidates, Lookup lookup)
		{
			foreach (var candidate in candidates)
				lookup.AddToResult(candidate);
		}

		private static Request BuildRequest(Lookup lookup)
		{
			var request = new Request();

			request.SetParameter("input_id", lookup.InputId);
			request.SetParameter("country", lookup.Country);
			request.SetParameter("locality", lookup.Locality);
			request.SetParameter("administrative_area", lookup.AdministrativeArea);
			request.SetParameter("postal_code", lookup.PostalCode);

			foreach (KeyValuePair<string, string> line in lookup.CustomParamDict)
			{
				request.SetParameter(line.Key, line.Value);
			}

			return request;
		}

		public void Dispose()
		{
			if (!this.senderIsDisposed)
			{
				this.sender.Dispose();
				this.senderIsDisposed = true;
			}
		}
	}
}

