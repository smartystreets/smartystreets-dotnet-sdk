namespace SmartyStreets.USAutocompleteApi
{
	using System.Runtime.Serialization;

	/// <remarks>
	///     See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-response"
	/// </remarks>
	/// >
	[DataContract]
	public class Suggestion
	{
		[DataMember(Name = "text")]
		public string Text { get; set; }

		[DataMember(Name = "street_line")]
		public string StreetLine { get; set; }

		[DataMember(Name = "city")]
		public string City { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }
	}
}