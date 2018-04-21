namespace SmartyStreets.USExtractApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
	/// </summary>
	[DataContract]
	public class Metadata
	{
		#region [ Fields ]

		[DataMember(Name = "lines")]
		public int Lines { get; set; }

		[DataMember(Name = "unicode")]
		public bool Unicode { get; set; }

		[DataMember(Name = "address_count")]
		public int AddressCount { get; set; }

		[DataMember(Name = "verified_count")]
		public int VerifiedCount { get; set; }

		[DataMember(Name = "bytes")]
		public int Bytes { get; set; }

		[DataMember(Name = "character_count")]
		public int CharacterCount { get; set; }

		#endregion
	}
}