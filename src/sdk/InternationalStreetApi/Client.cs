using System.IO;

namespace SmartyStreets.InternationalStreetApi
{
    public class Client
    {
        private ISender sender;
        private ISerializer serializer;

        public Client(ISender sender, ISerializer serializer)
        {
            this.sender = sender;
            this.serializer = serializer;
        }

        public Candidate[] Send(Lookup lookup)
        {
            EnsureEnoughInfo(lookup);
            var request = BuildRequest(lookup);

            var response = this.sender.Send(request);

            using (var payloadStream = new MemoryStream(response.Payload))
            {
                var candidates = this.serializer.Deserialize<Candidate[]>(payloadStream) ?? new Candidate[0];
                lookup.Result = candidates;
                return candidates;
            }
        }

        private Request BuildRequest(Lookup lookup)
        {
            var request = new Request();

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

            return request;
        }

        private void EnsureEnoughInfo(Lookup lookup)
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