namespace SmartyStreets.InternationalStreetApi
{
	using System;
	using System.Collections.Generic;
	using System.IO;
    using System.Threading.Tasks;

    public class Client : IInternationalStreetClient
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

			EnsureEnoughInfo(lookup);
			var request = BuildRequest(lookup);

			var response = await this.sender.Send(request);

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
			request.SetParameter("geocode", lookup.Geocode ? lookup.Geocode.ToString().ToLower() : null);
			if (lookup.Language != null)
				request.SetParameter("language", lookup.Language);
			request.SetParameter("freeform", lookup.Freeform);
			request.SetParameter("address1", lookup.Address1);
			request.SetParameter("address2", lookup.Address2);
			request.SetParameter("address3", lookup.Address3);
			request.SetParameter("address4", lookup.Address4);
			request.SetParameter("organization", lookup.Organization);
			request.SetParameter("locality", lookup.Locality);
			request.SetParameter("administrative_area", lookup.AdministrativeArea);
			request.SetParameter("postal_code", lookup.PostalCode);

			foreach (KeyValuePair<string, string> line in lookup.CustomParamDict) {
				request.SetParameter(line.Key, line.Value);
			}

			return request;
		}

		private static void EnsureEnoughInfo(Lookup lookup)
		{
			if (lookup.MissingCountry())
				throw new UnprocessableEntityException("Country field is required.");

			if (lookup.HasFreeform())
				return;

			if (lookup.MissingAddress1())
				throw new UnprocessableEntityException("Either freeform or address1 is required.");

			if (lookup.HasPostalCode())
				return;

			if (lookup.MissingLocalityOrAdministrativeArea())
				throw new UnprocessableEntityException("Insufficient information: One or more required fields " +
				                                       "were not set on the lookup.");
		}
	}
}