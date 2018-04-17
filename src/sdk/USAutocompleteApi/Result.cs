namespace SmartyStreets.USAutocompleteApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Result
	{
		[DataMember(Name = "suggestions")]
		public Suggestion[] Suggestions { get; private set; }
	}
}