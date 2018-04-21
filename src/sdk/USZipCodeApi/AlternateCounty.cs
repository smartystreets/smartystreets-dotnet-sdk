namespace SmartyStreets.USZipCodeApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/us-zipcode-api#zipcodes"
	/// </summary>
	[DataContract]
	public class AlternateCounty
	{
		[DataMember(Name = "county_fips")]
		public string CountyFips { get; set; }

		[DataMember(Name = "county_name")]
		public string CountyName { get; set; }

		[DataMember(Name = "state_abbreviation")]
		public string StateAbbreviation { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }
	}
}