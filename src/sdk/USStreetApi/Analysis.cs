using System.Runtime.Serialization;

namespace SmartyStreets.USStreetApi
{
	[DataContract]
	public class Analysis
	{
		#region [ Fields ]

		[DataMember(Name = "dpv_match_code")]
		public string DpvMatchCode { get; private set; }

		[DataMember(Name = "dpv_footnotes")]
		public string DpvFootnotes { get; private set; }

		[DataMember(Name = "dpv_cmra")]
		public string Cmra { get; private set; }

		[DataMember(Name = "dpv_vacant")]
		public string Vacant { get; private set; }

		[DataMember(Name = "active")]
		public string Active { get; private set; }

		[DataMember(Name = "ews_match")]
		public bool IsEwsMatch { get; private set; }

		[DataMember(Name = "footnotes")]
		public string Footnotes { get; private set; }

		[DataMember(Name = "lacslink_code")]
		public string LacsLinkCode { get; private set; }

		[DataMember(Name = "lacslink_indicator")]
		public string LacsLinkIndicator { get; private set; }

		[DataMember(Name = "suitelink_match")]
		public bool IsSuiteLinkMatch { get; private set; }

		#endregion
	}
}

