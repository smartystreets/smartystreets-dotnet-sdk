namespace SmartyStreets.USReverseGeoApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     A result is a possible match for an lat/lon that was submitted.
	///     A lookup can have multiple results if the address was ambiguous.
	/// </summary>
	/// <remarks>See "https://smartystreets.com/docs/cloud/us-reverse-geo-api#result"</remarks>
	[DataContract]
	public class Result
	{
		#region [ Fields ]
		
		[DataMember(Name = "coordinate")]
		public Coordinate Coordinate { get; set; }
		
		[DataMember(Name = "distance")]
		public double Distance { get; set; }
		
		[DataMember(Name = "address")]
		public Address Address { get; set; }

		#endregion
	}
}