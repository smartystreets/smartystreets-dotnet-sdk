namespace SmartyStreets.USZipCodeApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class ZipCodeEntry
	{
		#region [ Fields ]

		[DataMember(Name = "zipcode")]
		public string ZipCode { get; set; }

		[DataMember(Name = "zipcode_type")]
		public string ZipCodeType { get; set; }

		[DataMember(Name = "default_city")]
		public string DefaultCity { get; set; }

		[DataMember(Name = "county_fips")]
		public string CountyFips { get; set; }

		[DataMember(Name = "county_name")]
		public string CountyName { get; set; }

		[DataMember(Name = "state_abbreviation")]
		public string StateAbbreviation { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }

		[DataMember(Name = "latitude")]
		public double Latitude { get; set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; set; }

		[DataMember(Name = "precision")]
		public string Precision { get; set; }

		[DataMember(Name = "alternate_counties")]
		public AlternateCounty[] AlternateCounties { get; set; }

		#endregion
	}
}