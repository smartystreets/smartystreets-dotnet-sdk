using System;
using System.Runtime.Serialization;

namespace SmartyStreets
{
	[DataContract]
	public class Analysis
	{
		#region [ Fields ]

		[DataMember(Name = "dpv_match_code")]
		private string DpvMatchCode { get; private set; }

		[DataMember(Name = "dpv_footnotes")]
		private string DpvFootnotes { get; private set; }

		[DataMember(Name = "dpv_cmra")]
		private string Cmra { get; private set; }

		[DataMember(Name = "dpv_vacant")]
		private string Vacant { get; private set; }

		[DataMember(Name = "active")]
		private string Active { get; private set; }

		[DataMember(Name = "ews_match")]
		private bool IsEwsMatch { get; private set; }

		[DataMember(Name = "footnotes")]
		private string Footnotes { get; private set; }

		[DataMember(Name = "lacslink_code")]
		private string LacsLinkCode { get; private set; }

		[DataMember(Name = "lacslink_indicator")]
		private string LacsLinkIndicator { get; private set; }

		[DataMember(Name = "suitelink_match")]
		private bool IsSuiteLinkMatch { get; private set; }

		#endregion

		public Analysis()
		{
		}
	}
}

