using System;
using System.IO;

namespace SmartyStreets
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
				request.AddHeader("X-Include-Invalid", "true");
			else if (batch.StandardizeOnly)
				request.AddHeader("X-Standardize-Only", "true");
		}

		private void PopulateQueryString(Lookup address, Request request)
		{
			request.AddParameter("street", address.Street);
			request.AddParameter("street2", address.Street2);
			request.AddParameter("secondary", address.Secondary);
			request.AddParameter("city", address.City);
			request.AddParameter("state", address.State);
			request.AddParameter("zipcode", address.ZipCode);
			request.AddParameter("lastline", address.Lastline);
			request.AddParameter("addressee", address.Addressee);
			request.AddParameter("urbanization", address.Urbanization);

			if (address.MaxCandidates != 1)
				request.AddParameter("candidates", address.MaxCandidates.ToString());
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
