using System;
using System.Runtime.Serialization;

namespace SmartyStreets
{
	[DataContract]
	public class Components
	{
		#region [ Fields ]

		[DataMember(Name = "urbanization")]
		public string Urbanization { get; private set; }

		[DataMember(Name = "primary_number")]
		public string PrimaryNumber { get; private set; }

		[DataMember(Name = "street_name")]
		public string StreetName { get; private set; }

		[DataMember(Name = "street_predirection")]
		public string StreetPredirection { get; private set; }

		[DataMember(Name = "street_postdirection")]
		public string StreetPostdirection { get; private set; }

		[DataMember(Name = "street_suffix")]
		public string StreetSuffix { get; private set; }

		[DataMember(Name = "secondary_number")]
		public string SecondaryNumber { get; private set; }

		[DataMember(Name = "secondary_designator")]
		public string SecondaryDesignator { get; private set; }

		[DataMember(Name = "extra_secondary_number")]
		public string ExtraSecondaryNumber { get; private set; }

		[DataMember(Name = "extra_secondary_designator")]
		public string ExtraSecondaryDesignator { get; private set; }

		[DataMember(Name = "pmb_designator")]
		public string PmbDesignator { get; private set; }

		[DataMember(Name = "pmb_number")]
		public string PmbNumber { get; private set; }

		[DataMember(Name = "city_name")]
		public string CityName { get; private set; }

		[DataMember(Name = "default_city_name")]
		public string DefaultCityName { get; private set; }

		[DataMember(Name = "state_abbreviation")]
		public string State { get; private set; }

		[DataMember(Name = "zipcode")]
		public string ZipCode { get; private set; }

		[DataMember(Name = "plus4_code")]
		public string Plus4Code { get; private set; }

		[DataMember(Name = "delivery_point")]
		public string DeliveryPoint { get; private set; }

		[DataMember(Name = "delivery_point_check_digit")]
		public string DeliveryPointCheckDigit { get; private set; }

		#endregion

		public Components()
		{
		}
	}
}

