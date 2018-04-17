namespace SmartyStreets.InternationalStreetApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/international-street-api#components"
	/// </summary>
	[DataContract]
	public class Components
	{
		#region [ Fields ]

		[DataMember(Name = "country_iso_3")]
		public string CountryIso3 { get; private set; }

		[DataMember(Name = "super_administrative_area")]
		public string SuperAdministrativeArea { get; private set; }

		[DataMember(Name = "administrative_area")]
		public string AdministrativeArea { get; private set; }

		[DataMember(Name = "sub_administrative_area")]
		public string SubAdministrativeArea { get; private set; }

		[DataMember(Name = "dependent_locality")]
		public string DependentLocality { get; private set; }

		[DataMember(Name = "dependent_locality_name")]
		public string DependentLocalityName { get; private set; }

		[DataMember(Name = "double_dependent_locality")]
		public string DoubleDependentLocality { get; private set; }

		[DataMember(Name = "locality")]
		public string Locality { get; private set; }

		[DataMember(Name = "postal_code")]
		public string PostalCode { get; private set; }

		[DataMember(Name = "postal_code_short")]
		public string PostalCodeShort { get; private set; }

		[DataMember(Name = "postal_code_extra")]
		public string PostalCodeExtra { get; private set; }

		[DataMember(Name = "premise")]
		public string Premise { get; private set; }

		[DataMember(Name = "premise_extra")]
		public string PremiseExtra { get; private set; }

		[DataMember(Name = "premise_number")]
		public string PremiseNumber { get; private set; }

		[DataMember(Name = "premise_type")]
		public string PremiseType { get; private set; }

		[DataMember(Name = "thoroughfare")]
		public string Thoroughfare { get; private set; }

		[DataMember(Name = "thoroughfare_predirection")]
		public string ThoroughfarePredirection { get; private set; }

		[DataMember(Name = "thoroughfare_postdirection")]
		public string ThoroughfarePostdirection { get; private set; }

		[DataMember(Name = "thoroughfare_name")]
		public string ThoroughfareName { get; private set; }

		[DataMember(Name = "thoroughfare_trailing_type")]
		public string ThoroughfareTrailingType { get; private set; }

		[DataMember(Name = "thoroughfare_type")]
		public string ThoroughfareType { get; private set; }

		[DataMember(Name = "dependent_thoroughfare")]
		public string DependentThoroughfare { get; private set; }

		[DataMember(Name = "dependent_thoroughfare_predirection")]
		public string DependentThoroughfarePredirection { get; private set; }

		[DataMember(Name = "dependent_thoroughfare_postdirection")]
		public string DependentThoroughfarePostdirection { get; private set; }

		[DataMember(Name = "dependent_thoroughfare_name")]
		public string DependentThoroughfareName { get; private set; }

		[DataMember(Name = "dependent_thoroughfare_trailing_type")]
		public string DependentThoroughfareTrailingType { get; private set; }

		[DataMember(Name = "dependent_thoroughfare_type")]
		public string DependentThoroughfareType { get; private set; }

		[DataMember(Name = "building")]
		public string Building { get; private set; }

		[DataMember(Name = "building_leading_type")]
		public string BuildingLeadingType { get; private set; }

		[DataMember(Name = "building_name")]
		public string BuildingName { get; private set; }

		[DataMember(Name = "building_trailing_type")]
		public string BuildingTrailingType { get; private set; }

		[DataMember(Name = "sub_building_type")]
		public string SubBuildingType { get; private set; }

		[DataMember(Name = "sub_building_number")]
		public string SubBuildingNumber { get; private set; }

		[DataMember(Name = "sub_building_name")]
		public string SubBuildingName { get; private set; }

		[DataMember(Name = "sub_building")]
		public string SubBuilding { get; private set; }

		[DataMember(Name = "post_box")]
		public string PostBox { get; private set; }

		[DataMember(Name = "post_box_type")]
		public string PostBoxType { get; private set; }

		[DataMember(Name = "post_box_number")]
		public string PostBoxNumber { get; private set; }

		#endregion
	}
}