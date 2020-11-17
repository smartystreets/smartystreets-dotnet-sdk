using System.Collections.Generic;

namespace SmartyStreets.USReverseGeoApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class SmartyResponse
	{
		#region [ Fields ]
		
		[DataMember(Name = "results")]
		public List<Result> Results { get; set; }

		#endregion
	}
}