namespace SmartyStreets.USExtractApi
{
	using System.Runtime.Serialization;

	/// <summary>
	/// See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
	/// </summary>
	[DataContract]
	public class Metadata
	{
		#region [ Fields ]

		[DataMember(Name = "lines")]
		public int lines { get; private set; }

		[DataMember(Name = "unicode")]
		public bool unicode { get; private set; }

		[DataMember(Name = "address_count")]
		public int addressCount { get; private set; }

		[DataMember(Name = "verified_count")]
		public int verifiedCount { get; private set; }

		[DataMember(Name = "bytes")]
		public int bytes { get; private set; }

		[DataMember(Name = "character_count")]
		public int characterCount { get; private set; }

		#endregion
	}
}
