namespace SmartyStreets.InternationalStreetApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/international-street-api#analysis"
	/// </summary>
	[DataContract]
	public class Analysis
	{
		[DataMember(Name = "verification_status")]
		public string VerificationStatus { get; set; }

		[DataMember(Name = "address_precision")]
		public string AddressPrecision { get; set; }

		[DataMember(Name = "max_address_precision")]
		public string MaxAddressPrecision { get; set; }
		
		[DataMember(Name = "changes")]
		public Changes Changes { get; set; }
	}
}