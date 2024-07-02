namespace SmartyStreets.InternationalAutocompleteApi
{
    using System.Runtime.Serialization;

	/// <remarks>
	///     See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-response"
	/// </remarks>
	/// >
	[DataContract]
	public class Candidate
	{
		[DataMember(Name = "street")]
		public string Street { get; set; }

		[DataMember(Name = "locality")]
		public string Locality { get; set; }

		[DataMember(Name = "administrative_area")]
		public string AdministrativeArea { get; set; }

		[DataMember(Name = "administrative_area_short")]
		public string AdministrativeAreaShort { get; set; }

		[DataMember(Name = "administrative_area_long")]
		public string AdministrativeAreaLong { get; set; }

		[DataMember(Name = "postal_code")]
		public string PostalCode { get; set; }
		
		[DataMember(Name = "country_iso3")]
		public string CountryISO3 { get; set; }

		[DataMember(Name = "entries")]
		public string Entries {get; set; }

		[DataMember(Name = "address_text")]
		public string AddressText {get; set; }

		[DataMember(Name = "address_id")]
		public string AddressID {get; set; }


	}
}