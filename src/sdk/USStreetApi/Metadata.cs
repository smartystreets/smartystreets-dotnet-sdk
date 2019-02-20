namespace SmartyStreets.USStreetApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Metadata
	{
		#region [ Fields ]

		[DataMember(Name = "record_type")]
		public string RecordType { get; set; }

		[DataMember(Name = "zip_type")]
		public string ZipType { get; set; }

		[DataMember(Name = "county_fips")]
		public string CountyFips { get; set; }

		[DataMember(Name = "county_name")]
		public string CountyName { get; set; }

		[DataMember(Name = "carrier_route")]
		public string CarrierRoute { get; set; }

		[DataMember(Name = "congressional_district")]
		public string CongressionalDistrict { get; set; }

		[DataMember(Name = "building_default_indicator")]
		public string BuildingDefaultIndicator { get; set; }

		[DataMember(Name = "rdi")]
		public string Rdi { get; set; }

		[DataMember(Name = "elot_sequence")]
		public string ElotSequence { get; set; }

		[DataMember(Name = "elot_sort")]
		public string ElotSort { get; set; }

		[DataMember(Name = "latitude")]
		public double Latitude { get; set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; set; }

		[DataMember(Name = "precision")]
		public string Precision { get; set; }

		[DataMember(Name = "time_zone")]
		public string TimeZone { get; set; }

		[DataMember(Name = "utc_offset")]
		public double UtcOffset { get; set; }

		[DataMember(Name = "dst")]
		public bool ObeysDst { get; set; }
		
		[DataMember(Name = "ews_match")]
		public bool IsEwsMatch { get; set; }

		#endregion
	}
}