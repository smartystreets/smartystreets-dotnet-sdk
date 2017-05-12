using System.Runtime.Serialization;

namespace SmartyStreets.USAutocompleteApi
{
    /// <remarks>
    /// See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-response"
    /// </remarks>>
    [DataContract]
    public class Suggestion
    {
        [DataMember(Name = "text")]
        public string Text { get; }

        [DataMember(Name = "street_line")]
        public string StreetLine { get; }

        [DataMember(Name = "city")]
        public string City { get; }

        [DataMember(Name = "state")]
        public string State { get; }
    }
}