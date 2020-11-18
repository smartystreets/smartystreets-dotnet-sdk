namespace SmartyStreets.USReverseGeoApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/us-reverse-geo-api#coordinate"
	/// </summary>
	[DataContract]
	public class Coordinate
	{
		#region [ Fields ]

		[DataMember(Name = "latitude")]
		public double Latitude { get; set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; set; }

		[DataMember(Name = "accuracy")]
		public string Accuracy { get; set; }

		[DataMember(Name = "license")]
		public int License { get; set; }
		
		#endregion
	}
}