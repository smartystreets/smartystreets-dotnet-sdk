using System;
using System.Runtime.Serialization;

namespace SmartyStreets
{
	[DataContract]
	public class Metadata
	{
		#region [ Fields ]

		[DataMember(Name = "record_type")]
		private string RecordType { get; private set; }

		[DataMember(Name = "zip_type")]
		private string ZipType { get; private set; }

		[DataMember(Name = "county_fips")]
		private string CountyFips { get; private set; }

		[DataMember(Name = "county_name")]
		private string CountyName { get; private set; }

		[DataMember(Name = "carrier_route")]
		private string CarrierRoute { get; private set; }

		[DataMember(Name = "congressional_district")]
		private string CongressionalDistrict { get; private set; }

		[DataMember(Name = "building_default_indicator")]
		private string BuildingDefaultIndicator { get; private set; }

		[DataMember(Name = "rdi")]
		private string Rdi { get; private set; }

		[DataMember(Name = "elot_sequence")]
		private string ElotSequence { get; private set; }

		[DataMember(Name = "elot_sort")]
		private string ElotSort { get; private set; }

		[DataMember(Name = "latitude")]
		private double Latitude { get; private set; }

		[DataMember(Name = "longitude")]
		private double Longitude { get; private set; }

		[DataMember(Name = "precision")]
		private string Precision { get; private set; }

		[DataMember(Name = "time_zone")]
		private string TimeZone { get; private set; }

		[DataMember(Name = "utc_offset")]
		private double UtcOffset { get; private set; }

		[DataMember(Name = "dst")]
		private bool ObeysDst { get; private set; }

		#endregion

		public Metadata()
		{
		}
	}
}

