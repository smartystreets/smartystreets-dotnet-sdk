using System;
using System.Runtime.Serialization;

namespace SmartyStreets
{
	[DataContract]
	public class Components
	{
		#region [ Fields ]

		[DataMember(Name = "urbanization")]
		private string Urbanization { get; private set; }

		[DataMember(Name = "primary_number")]
		private string PrimaryNumber { get; private set; }

		[DataMember(Name = "street_name")]
		private string StreetName { get; private set; }

		[DataMember(Name = "street_predirection")]
		private string StreetPredirection { get; private set; }

		[DataMember(Name = "street_postdirection")]
		private string StreetPostdirection { get; private set; }

		[DataMember(Name = "street_suffix")]
		private string StreetSuffix { get; private set; }

		[DataMember(Name = "secondary_number")]
		private string SecondaryNumber { get; private set; }

		[DataMember(Name = "secondary_designator")]
		private string SecondaryDesignator { get; private set; }

		[DataMember(Name = "extra_secondary_number")]
		private string ExtraSecondaryNumber { get; private set; }

		[DataMember(Name = "extra_secondary_designator")]
		private string ExtraSecondaryDesignator { get; private set; }

		[DataMember(Name = "pmb_designator")]
		private string PmbDesignator { get; private set; }

		[DataMember(Name = "pmb_number")]
		private string PmbNumber { get; private set; }

		[DataMember(Name = "city_name")]
		private string CityName { get; private set; }

		[DataMember(Name = "default_city_name")]
		private string DefaultCityName { get; private set; }

		[DataMember(Name = "state_abbreviation")]
		private string State { get; private set; }

		[DataMember(Name = "zipcode")]
		private string ZipCode { get; private set; }

		[DataMember(Name = "plus4_code")]
		private string Plus4Code { get; private set; }

		[DataMember(Name = "delivery_point")]
		private string DeliveryPoint { get; private set; }

		[DataMember(Name = "delivery_point_check_digit")]
		private string DeliveryPointCheckDigit { get; private set; }

		#endregion

		public Components()
		{
		}
	}
}

