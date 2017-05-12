namespace SmartyStreets.USStreetApi
{
	using System.Globalization;
	using System.IO;

	public class Client
	{
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
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
			var request = new Request();

			if (batch.Count == 0)
				return;

			if (batch.Count == 1)
				PopulateQueryString(batch[0], request);
			else
				request.Payload = batch.Serialize(this.serializer);

			var response = this.sender.Send(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var candidates = this.serializer.Deserialize<Candidate[]>(payloadStream) ?? new Candidate[0];
				AssignCandidatesToLookups(batch, candidates);
			}
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
			request.SetParameter("match", address.MatchStrategy);

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