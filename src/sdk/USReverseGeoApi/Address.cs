namespace SmartyStreets.USReverseGeoApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/us-reverse-geo-api#address"
	/// </summary>
	[DataContract]
	public class Address
	{
		#region [ Fields ]

		[DataMember(Name = "street")]
		public string Street { get; set; }

		[DataMember(Name = "city")]
		public string City { get; set; }

		[DataMember(Name = "state_abbreviation")]
		public string StateAbbreviation { get; set; }

		[DataMember(Name = "zipcode")]
		public string Zipcode { get; set; }
		
		#endregion
	}
}