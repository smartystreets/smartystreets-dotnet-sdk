namespace SmartyStreets.InternationalAutocompleteApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Result
	{
		[DataMember(Name = "candidates")]
		public Candidate[] Candidates { get; set; }
	}
}