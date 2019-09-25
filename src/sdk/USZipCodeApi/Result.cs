namespace SmartyStreets.USZipCodeApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Result
	{
		#region [ Fields ]

		[DataMember(Name = "status")]
		public string Status { get; set; }

		[DataMember(Name = "reason")]
		public string Reason { get; set; }

		[DataMember(Name = "input_id")]
		public string InputId { get; set; }

		[DataMember(Name = "input_index")]
		public int InputIndex { get; set; }

		[DataMember(Name = "city_states")]
		public CityEntry[] CityStates { get; set; }

		[DataMember(Name = "zipcodes")]
		public ZipCodeEntry[] ZipCodes { get; set; }

		#endregion

		public bool IsValid()
		{
			return this.Status == null && this.Reason == null;
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