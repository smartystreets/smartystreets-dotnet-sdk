namespace SmartyStreets.USZipCodeApi
{
	using System.Runtime.Serialization;

	[DataContract]
	public class ZipCodeEntry
	{
		#region [ Fields ]

		[DataMember(Name = "zipcode")]
		public string ZipCode { get; private set; }

		[DataMember(Name = "zipcode_type")]
		public string ZipCodeType { get; private set; }

		[DataMember(Name = "default_city")]
		public string DefaultCity { get; private set; }

		[DataMember(Name = "county_fips")]
		public string CountyFips { get; private set; }

		[DataMember(Name = "county_name")]
		public string CountyName { get; private set; }

		[DataMember(Name = "latitude")]
		public double Latitude { get; private set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; private set; }

		[DataMember(Name = "precision")]
		public string Precision { get; private set; }

		#endregion
	}
}
