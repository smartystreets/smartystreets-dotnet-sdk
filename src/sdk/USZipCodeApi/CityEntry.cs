namespace SmartyStreets.USZipCodeApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class CityEntry
	{
		#region [ Fields ]

		[DataMember(Name = "city")]
		public string City { get; set; }

		[DataMember(Name = "mailable_city")]
		public bool MailableCity { get; set; }

		[DataMember(Name = "state_abbreviation")]
		public string StateAbbreviation { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }

		#endregion
	}
}