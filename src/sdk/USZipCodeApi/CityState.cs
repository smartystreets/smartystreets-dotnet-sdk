using System.Runtime.Serialization;

namespace SmartyStreets.USZipCodeApi
{
	[DataContract]
	public class CityState
	{
		#region [ Fields ]

		[DataMember(Name = "city")]
		public string City { get; private set; }

		[DataMember(Name = "mailable_city")]
		public bool MailableCity { get; private set; }

		[DataMember(Name = "state_abbreviation")]
		public string StateAbbreviation { get; private set; }

		[DataMember(Name = "state")]
		public string State { get; private set; }

		#endregion
	}
}

