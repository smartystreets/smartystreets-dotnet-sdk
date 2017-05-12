using System.Runtime.Serialization;

namespace SmartyStreets.USAutocompleteApi
{
    [DataContract]
    public class Result
    {
        [DataMember(Name = "suggestions")]
        public Suggestion[] Suggestions { get; private set; }
    }
}