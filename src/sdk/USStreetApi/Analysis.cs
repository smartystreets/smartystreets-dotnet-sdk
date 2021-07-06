using System;

namespace SmartyStreets.USStreetApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Analysis
	{
		#region [ Fields ]

		[DataMember(Name = "dpv_match_code")]
		public string DpvMatchCode { get; set; }

		[DataMember(Name = "dpv_footnotes")]
		public string DpvFootnotes { get; set; }

		[DataMember(Name = "dpv_cmra")]
		public string Cmra { get; set; }

		[DataMember(Name = "dpv_vacant")]
		public string Vacant { get; set; }

		[DataMember(Name = "dpv_no_stat")]
		public string NoStat { get; set; }

		[DataMember(Name = "active")]
		public string Active { get; set; }

		[Obsolete("Analysis.ews_match is deprecated, refer to Metadata.ews_match instead.")]
		[DataMember(Name = "ews_match")]
		public bool IsEwsMatch { get; set; }

		[DataMember(Name = "footnotes")]
		public string Footnotes { get; set; }

		[DataMember(Name = "lacslink_code")]
		public string LacsLinkCode { get; set; }

		[DataMember(Name = "lacslink_indicator")]
		public string LacsLinkIndicator { get; set; }

		[DataMember(Name = "suitelink_match")]
		public bool IsSuiteLinkMatch { get; set; }

		[DataMember(Name = "enhanced_match")]
		public string EnhancedMatch { get; set; }

		#endregion
	}
}