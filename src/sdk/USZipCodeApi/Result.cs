using System.Runtime.Serialization;

namespace SmartyStreets.USZipCodeApi
{
	[DataContract]
	public class Result
	{
		#region [ Fields ]

		[DataMember(Name = "status")]
		public string Status { get; private set; }

		[DataMember(Name = "reason")]
		public string Reason { get; private set; }

		[DataMember(Name = "input_index")]
		public int InputIndex { get; private set; }

		[DataMember(Name = "city_states")]
		public CityEntry[] CityStates { get; private set; }

		[DataMember(Name = "zipcodes")]
		public ZipCodeEntry[] ZipCodes { get; private set; }

		#endregion

		public bool IsValid()
		{
			return (this.Status == null && this.Reason == null);
		}

		public CityEntry GetCityState(int index)
		{
			return this.CityStates[index];
		}

		public ZipCodeEntry GetZipCode(int index)
		{
			return this.ZipCodes[index];
		}
	}
}

