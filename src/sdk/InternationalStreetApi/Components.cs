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
		public string CountryIso3 { get; set; }

		[DataMember(Name = "super_administrative_area")]
		public string SuperAdministrativeArea { get; set; }

		[DataMember(Name = "administrative_area")]
		public string AdministrativeArea { get; set; }

		[DataMember(Name = "administrative_area_short")]
		public string AdministrativeAreaShort { get; set; }

		[DataMember(Name = "administrative_area_long")]
		public string AdministrativeAreaLong { get; set; }

		[DataMember(Name = "sub_administrative_area")]
		public string SubAdministrativeArea { get; set; }

		[DataMember(Name = "dependent_locality")]
		public string DependentLocality { get; set; }

		[DataMember(Name = "dependent_locality_name")]
		public string DependentLocalityName { get; set; }

		[DataMember(Name = "double_dependent_locality")]
		public string DoubleDependentLocality { get; set; }

		[DataMember(Name = "locality")]
		public string Locality { get; set; }

		[DataMember(Name = "postal_code")]
		public string PostalCode { get; set; }

		[DataMember(Name = "postal_code_short")]
		public string PostalCodeShort { get; set; }

		[DataMember(Name = "postal_code_extra")]
		public string PostalCodeExtra { get; set; }

		[DataMember(Name = "premise")]
		public string Premise { get; set; }

		[DataMember(Name = "premise_extra")]
		public string PremiseExtra { get; set; }

		[DataMember(Name = "premise_number")]
		public string PremiseNumber { get; set; }

		[DataMember(Name = "premise_number_prefix")]
		public string PremiseNumberPrefix { get; set; }

		[DataMember(Name = "premise_type")]
		public string PremiseType { get; set; }

		[DataMember(Name = "thoroughfare")]
		public string Thoroughfare { get; set; }

		[DataMember(Name = "thoroughfare_predirection")]
		public string ThoroughfarePredirection { get; set; }

		[DataMember(Name = "thoroughfare_postdirection")]
		public string ThoroughfarePostdirection { get; set; }

		[DataMember(Name = "thoroughfare_name")]
		public string ThoroughfareName { get; set; }

		[DataMember(Name = "thoroughfare_trailing_type")]
		public string ThoroughfareTrailingType { get; set; }

		[DataMember(Name = "thoroughfare_type")]
		public string ThoroughfareType { get; set; }

		[DataMember(Name = "dependent_thoroughfare")]
		public string DependentThoroughfare { get; set; }

		[DataMember(Name = "dependent_thoroughfare_predirection")]
		public string DependentThoroughfarePredirection { get; set; }

		[DataMember(Name = "dependent_thoroughfare_postdirection")]
		public string DependentThoroughfarePostdirection { get; set; }

		[DataMember(Name = "dependent_thoroughfare_name")]
		public string DependentThoroughfareName { get; set; }

		[DataMember(Name = "dependent_thoroughfare_trailing_type")]
		public string DependentThoroughfareTrailingType { get; set; }

		[DataMember(Name = "dependent_thoroughfare_type")]
		public string DependentThoroughfareType { get; set; }

		[DataMember(Name = "building")]
		public string Building { get; set; }

		[DataMember(Name = "building_leading_type")]
		public string BuildingLeadingType { get; set; }

		[DataMember(Name = "building_name")]
		public string BuildingName { get; set; }

		[DataMember(Name = "building_trailing_type")]
		public string BuildingTrailingType { get; set; }

		[DataMember(Name = "sub_building_type")]
		public string SubBuildingType { get; set; }

		[DataMember(Name = "sub_building_number")]
		public string SubBuildingNumber { get; set; }

		[DataMember(Name = "sub_building_name")]
		public string SubBuildingName { get; set; }

		[DataMember(Name = "sub_building")]
		public string SubBuilding { get; set; }

		[DataMember(Name = "level_type")]
		public string LevelType { get; set; }

		[DataMember(Name = "level_number")]
		public string LevelNumber { get; set; }

		[DataMember(Name = "post_box")]
		public string PostBox { get; set; }

		[DataMember(Name = "post_box_type")]
		public string PostBoxType { get; set; }

		[DataMember(Name = "post_box_number")]
		public string PostBoxNumber { get; set; }

		#endregion
	}
}