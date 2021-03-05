namespace SmartyStreets.USAutocompleteProApi
{
	using System.Runtime.Serialization;

	/// <remarks>
	///     See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-response"
	/// </remarks>
	/// >
	[DataContract]
	public class Suggestion
	{
		[DataMember(Name = "street_line")]
		public string Street { get; set; }

		[DataMember(Name = "secondary")]
		public string Secondary { get; set; }

		[DataMember(Name = "city")]
		public string City { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }
		
		[DataMember(Name = "zipcode")]
		public string ZIPCode { get; set; }
		
		[DataMember(Name = "entries")]
		public string Entries { get; set; }
	}
}