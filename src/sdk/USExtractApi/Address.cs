namespace SmartyStreets.USExtractApi
{
	using System.Runtime.Serialization;
	using SmartyStreets.USStreetApi;

	/// <summary>
	///  See "https://smartystreets.com/docs/cloud/us-extract-api#http-response-status"
	/// </summary>
	[DataContract]
	public class Address
	{
		#region [ Fields ]

		[DataMember(Name = "text")]
		public string Text { get; private set; }

		[DataMember(Name = "verified")]
		public bool Verified { get; private set; }

		[DataMember(Name = "line")]
		public int Line { get; private set; }

		[DataMember(Name = "start")]
		public int Start { get; private set; }

		[DataMember(Name = "end")]
		public int End { get; private set; }

		[DataMember(Name = "api_output")]
		public Candidate[] Candidates { get; private set; }

		#endregion
	}
}
