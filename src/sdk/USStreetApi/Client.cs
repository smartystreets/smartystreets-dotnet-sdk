using System.IO;

namespace SmartyStreets.USStreetApi
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

			this.putHeaders(batch, request);

			if (batch.Size() == 1)
				this.PopulateQueryString(batch.Get(0), request);
			else
				request.Payload = this.serializer.Serialize(batch.AllLookups);

			var response = this.sender.Send(request);
			var payloadStream = new MemoryStream(response.Payload);

			Candidate[] candidates = this.serializer.Deserialize<Candidate[]>(payloadStream);
			if (candidates == null)
				candidates = new Candidate[0];
			this.AssignCandidatesToLookups(batch, candidates);
		}

		private void putHeaders(Batch batch, Request request)
		{
			if (batch.IncludeInvalid)
				request.SetHeader("X-Include-Invalid", "true");
			else if (batch.StandardizeOnly)
				request.SetHeader("X-Standardize-Only", "true");
		}

		private void PopulateQueryString(Lookup address, Request request)
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
				request.SetParameter("candidates", address.MaxCandidates.ToString());
		}

		private void AssignCandidatesToLookups(Batch batch, Candidate[] candidates)
		{
			for (int i = 0; i < batch.Size(); i++)
			{
				foreach (Candidate candidate in candidates)
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
