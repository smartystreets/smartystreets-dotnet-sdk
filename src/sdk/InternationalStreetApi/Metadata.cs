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
		public double Latitude { get; private set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; private set; }

		[DataMember(Name = "geocode_precision")]
		public string GeocodePrecision { get; private set; }

		[DataMember(Name = "max_geocode_precision")]
		public string MaxGeocodePrecision { get; private set; }

		[DataMember(Name = "address_format")]
		public string AddressFormat { get; private set; }

		#endregion
	}
}