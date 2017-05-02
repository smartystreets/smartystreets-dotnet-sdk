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
		public string text { get; private set; }

		[DataMember(Name = "verified")]
		public bool verified { get; private set; }

		[DataMember(Name = "line")]
		public int line { get; private set; }

		[DataMember(Name = "start")]
		public int start { get; private set; }

		[DataMember(Name = "end")]
		public int end { get; private set; }

		[DataMember(Name = "api_output")]
		public Candidate[] candidates { get; private set; }

		#endregion
	}
}
