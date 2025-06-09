using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SmartyStreets.USStreetApi
{

	[DataContract]
	public class ComponentAnalysis
	{
		#region [ Fields ]

		[DataMember(Name = "primary_number")]
		public MatchInfo PrimaryNumber { get; set; }

		[DataMember(Name = "street_predirection")]
		public MatchInfo StreetPredirection { get; set; }

		[DataMember(Name = "street_name")]
		public MatchInfo StreetName { get; set; }

		[DataMember(Name = "street_postdirection")]
		public MatchInfo StreetPostdirection { get; set; }

		[DataMember(Name = "street_suffix")]
		public MatchInfo StreetSuffix { get; set; }

		[DataMember(Name = "secondary_number")]
		public MatchInfo SecondaryNumber { get; set; }

		[DataMember(Name = "secondary_designator")]
		public MatchInfo SecondaryDesignator { get; set; }

		[DataMember(Name = "extra_secondary_number")]
		public MatchInfo ExtraSecondaryNumber { get; set; }

		[DataMember(Name = "extra_secondary_designator")]
		public MatchInfo ExtraSecondaryDesignator { get; set; }

		[DataMember(Name = "city_name")]
		public MatchInfo CityName { get; set; }

		[DataMember(Name = "state_abbreviation")]
		public MatchInfo StateAbbreviation { get; set; }

		[DataMember(Name = "zipcode")]
		public MatchInfo ZIPCode { get; set; }

		[DataMember(Name = "plus4_code")]
		public MatchInfo Plus4Code { get; set; }

		[DataMember(Name = "urbanization")]
		public MatchInfo Urbanization { get; set; }

		#endregion
	}
}
