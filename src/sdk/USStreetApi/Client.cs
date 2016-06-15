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
			var batch = new Batch();
			batch.Add(lookup);
			this.Send(batch);
		}

		public void Send(Batch batch)
		{
			var request = new Request(this.urlPrefix);

			if (batch.Size() == 0)
				return;

			PutHeaders(batch, request);

			if (batch.Size() == 1)
				PopulateQueryString(batch.Get(0), request);
			else
				request.Payload = this.serializer.Serialize(batch.AllLookups);

			var response = this.sender.Send(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var candidates = this.serializer.Deserialize<Candidate[]>(payloadStream) ?? new Candidate[0];
				AssignCandidatesToLookups(batch, candidates);
			}
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
			for (var i = 0; i < batch.Size(); i++)
			{
				foreach (var candidate in candidates)
				{
					if (candidate.InputIndex == i)
					{
						batch.Get(i).AddToResult(candidate);
					}
				}
			}
		}
	}
}
