namespace SmartyStreets.InternationalStreetApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/international-street-api#metadata"
	/// </summary>
	[DataContract]
	public class Metadata
	{
		#region [ Fields ]

		[DataMember(Name = "latitude")]
		public double Latitude { get; set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; set; }

		[DataMember(Name = "geocode_precision")]
		public string GeocodePrecision { get; set; }

		[DataMember(Name = "max_geocode_precision")]
		public string MaxGeocodePrecision { get; set; }

		[DataMember(Name = "address_format")]
		public string AddressFormat { get; set; }

		[DataMember(Name = "occupant_use")]
		public string OccupantUse { get; set; }

		#endregion
	}
}