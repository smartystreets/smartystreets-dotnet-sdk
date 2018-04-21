namespace SmartyStreets.USExtractApi
{
	using System.Runtime.Serialization;
	using USStreetApi;

	/// <summary>
	///     See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
	/// </summary>
	[DataContract]
	public class Address
	{
		#region [ Fields ]

		[DataMember(Name = "text")]
		public string Text { get; set; }

		[DataMember(Name = "verified")]
		public bool Verified { get; set; }

		[DataMember(Name = "line")]
		public int Line { get; set; }

		[DataMember(Name = "start")]
		public int Start { get; set; }

		[DataMember(Name = "end")]
		public int End { get; set; }

		[DataMember(Name = "api_output")]
		public Candidate[] Candidates { get; set; }

		#endregion
	}
}