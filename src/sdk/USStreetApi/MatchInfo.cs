using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SmartyStreets.USStreetApi
{
	[DataContract]
	public class MatchInfo
	{
		#region [ Fields ]

		[DataMember(Name = "status")]
		public string Status { get; set; }

		[DataMember(Name = "change")]
		public List<string> Change { get; set; }

		#endregion
	}

}
