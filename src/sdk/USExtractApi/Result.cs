namespace SmartyStreets.USExtractApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
	/// </summary>
	[DataContract]
	public class Result
	{
		[DataMember(Name = "meta")]
		public Metadata Metadata { get; set; }

		[DataMember(Name = "addresses")]
		public Address[] Addresses { get; set; }
	}
}