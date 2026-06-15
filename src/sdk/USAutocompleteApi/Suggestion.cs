namespace SmartyStreets.USAutocompleteApi
{
	using System.Runtime.Serialization;

	/// <remarks>
	///     See "https://www.smarty.com/docs/apis/us-autocomplete-v2/reference#http-response-status"
	/// </remarks>
	/// >
	[DataContract]
	public class Suggestion
	{
		[DataMember(Name = "smarty_key")]
		public string SmartyKey { get; set; }

		[DataMember(Name = "entry_id")]
		public string EntryId { get; set; }

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
