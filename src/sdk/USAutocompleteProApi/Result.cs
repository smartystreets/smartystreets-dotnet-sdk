using SmartyStreets.USAutocompleteApi;

namespace SmartyStreets.USAutocompleteProApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Result
	{
		[DataMember(Name = "suggestions")]
		public Suggestion[] Suggestions { get; set; }
	}
}