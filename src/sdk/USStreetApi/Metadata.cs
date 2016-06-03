using System;
using System.Runtime.Serialization;

namespace SmartyStreets
{
	[DataContract]
	public class Metadata
	{
		#region [ Fields ]

		[DataMember(Name = "record_type")]
		public string RecordType { get; private set; }

		[DataMember(Name = "zip_type")]
		public string ZipType { get; private set; }

		[DataMember(Name = "county_fips")]
		public string CountyFips { get; private set; }

		[DataMember(Name = "county_name")]
		public string CountyName { get; private set; }

		[DataMember(Name = "carrier_route")]
		public string CarrierRoute { get; private set; }

		[DataMember(Name = "congressional_district")]
		public string CongressionalDistrict { get; private set; }

		[DataMember(Name = "building_default_indicator")]
		public string BuildingDefaultIndicator { get; private set; }

		[DataMember(Name = "rdi")]
		public string Rdi { get; private set; }

		[DataMember(Name = "elot_sequence")]
		public string ElotSequence { get; private set; }

		[DataMember(Name = "elot_sort")]
		public string ElotSort { get; private set; }

		[DataMember(Name = "latitude")]
		public double Latitude { get; private set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; private set; }

		[DataMember(Name = "precision")]
		public string Precision { get; private set; }

		[DataMember(Name = "time_zone")]
		public string TimeZone { get; private set; }

		[DataMember(Name = "utc_offset")]
		public double UtcOffset { get; private set; }

		[DataMember(Name = "dst")]
		public bool ObeysDst { get; private set; }

		#endregion

		public Metadata()
		{
		}
	}
}

