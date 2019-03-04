namespace SmartyStreets.InternationalStreetApi
{
	using System.Runtime.Serialization;

	/// <summary>
	///     A candidate is a possible match for an address that was submitted.
	///     A lookup can have multiple candidates if the address was ambiguous.
	/// </summary>
	/// <remarks>See "https://smartystreets.com/docs/cloud/international-street-api#root"</remarks>
	[DataContract]
	public class Candidate : RootLevel
	{
		#region [ Fields ]

		[DataMember(Name = "components")]
		public Components Components { get; set; }

		[DataMember(Name = "metadata")]
		public Metadata Metadata { get; set; }

		[DataMember(Name = "analysis")]
		public Analysis Analysis { get; set; }

		#endregion
	}
}