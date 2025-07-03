using SmartyStreets.USReverseGeoApi;

namespace SmartyStreets.USStreetApi
{
	using System;
	using System.Collections.Generic;
    using System.Globalization;
	using System.IO;
    using System.Threading.Tasks;

    public class Client : IUSStreetClient
	{
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public async Task Send(Lookup lookup)
		{
			if (lookup == null)
				throw new ArgumentNullException("lookup");

			await this.Send(new Batch {lookup});
		}

		/// <summary>
		///     Sends a batch of up to 100 lookups for verification
		/// </summary>
		public async Task Send(Batch batch)
		{
			if (batch == null)
				throw new ArgumentNullException("batch");

			var request = new Request();

			if (batch.Count == 0)
				return;

			if (batch.Count == 1)
				PopulateQueryString(batch[0], request);
			else
				Console.WriteLine("SERIALIZING BATCH");
				request.Payload = batch.Serialize(this.serializer);

			var response = await this.sender.Send(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var candidates = this.serializer.Deserialize<List<Candidate>>(payloadStream) ?? new List<Candidate>();
				AssignCandidatesToLookups(batch, candidates);
			}
		}

		private static void PopulateQueryString(Lookup address, Request request)
		{
			if (address.MatchStrategy == "enhanced" && address.MaxCandidates == 1)
				address.MaxCandidates = 5;
		    request.SetParameter("input_id", address.InputId);
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
			request.SetParameter("compatibility", address.Compatibility);
			request.SetParameter("county_source", address.CountySource);

			foreach (KeyValuePair<string, string> line in address.CustomParamDict) {
				request.SetParameter(line.Key, line.Value);
			}

			if (address.MaxCandidates != 1) 
				request.SetParameter("candidates", address.MaxCandidates.ToString(CultureInfo.InvariantCulture));
			
			request.SetParameter("format", address.OutputFormat);
		}

		private static void AssignCandidatesToLookups(Batch batch, IEnumerable<Candidate> candidates)
		{
			foreach (var candidate in candidates)
				batch[candidate.InputIndex].AddToResult(candidate);
		}
	}
}