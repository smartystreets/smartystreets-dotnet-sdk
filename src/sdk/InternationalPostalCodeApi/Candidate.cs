namespace SmartyStreets.InternationalPostalCodeApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     A candidate is a possible match for a postal code lookup.
	///     A lookup can have multiple candidates if the postal code was ambiguous.
	/// </summary>
	/// <remarks>See "https://smartystreets.com/docs/international-postal-code-api"</remarks>
	[DataContract]
	public class Candidate
	{
		#region [ Fields ]

		[DataMember(Name = "input_id")]
		public string InputId { get; set; }

		[DataMember(Name = "administrative_area")]
		public string AdministrativeArea { get; set; }

		[DataMember(Name = "sub_administrative_area")]
		public string SubAdministrativeArea { get; set; }

		[DataMember(Name = "super_administrative_area")]
		public string SuperAdministrativeArea { get; set; }

		[DataMember(Name = "country_iso_3")]
		public string CountryIso3 { get; set; }

		[DataMember(Name = "locality")]
		public string Locality { get; set; }

		[DataMember(Name = "dependent_locality")]
		public string DependentLocality { get; set; }

		[DataMember(Name = "dependent_locality_name")]
		public string DependentLocalityName { get; set; }

		[DataMember(Name = "double_dependent_locality")]
		public string DoubleDependentLocality { get; set; }

		[DataMember(Name = "postal_code")]
		public string PostalCode { get; set; }

		[DataMember(Name = "postal_code_extra")]
		public string PostalCodeExtra { get; set; }

		#endregion
	}
}

