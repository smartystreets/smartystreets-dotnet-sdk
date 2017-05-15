using System.Collections;
using System.IO;

namespace SmartyStreets.USAutocompleteApi
{
    /// <summary>
    /// This client sends lookups to the SmartyStreets US Autocomplete API,
    /// and attaches the results to the appropriate Lookup objects.
    /// </summary>
    public class Client
    {
        private ISender sender;
        private ISerializer serializer;

        public Client(ISender sender, ISerializer serializer)
        {
            this.sender = sender;
            this.serializer = serializer;
        }

        public Suggestion[] Send(Lookup lookup)
        {
            if (string.IsNullOrEmpty(lookup?.Prefix))
                throw new SmartyException("Send() must be passed a Lookup with the prefix field set.");

            var request = BuildRequest(lookup);

            var response = this.sender.Send(request);

            using (var payloadStream = new MemoryStream(response.Payload))
            {
                var result = this.serializer.Deserialize<Result>(payloadStream) ?? new Result();
                var suggestions = result.Suggestions;
                lookup.Result = suggestions;
                return suggestions;
            }
        }

        private Request BuildRequest(Lookup lookup)
        {
            var request = new Request();

            request.SetParameter("prefix", lookup.Prefix);
            request.SetParameter("suggestions", lookup.MaxSuggestions.ToString());
            request.SetParameter("city_filter", BuildFilterString(lookup.CityFilter));
            request.SetParameter("state_filter", BuildFilterString(lookup.StateFilter));
            request.SetParameter("prefer", BuildFilterString(lookup.Prefer));

            if (lookup.GeolocateType != GeolocateType.NONE)
            {
                request.SetParameter("geolocate", "true");
                request.SetParameter("geolocate_precision", lookup.GeolocateType);
            }
            else request.SetParameter("geolocate", "false");

            return request;
        }

        private string BuildFilterString(ArrayList list)
        {
            if (list.Count == 0)
                return null;

            var filterList = "";

            foreach (string item in list)
                filterList += (item + ",");

            if (filterList.EndsWith(","))
                filterList = filterList.Substring(0, filterList.Length - 1);

            return filterList;
        }
    }
}