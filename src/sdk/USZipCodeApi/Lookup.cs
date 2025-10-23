﻿namespace SmartyStreets.USZipCodeApi
{
	using System.Runtime.Serialization;
	using System.Collections.Generic;

	[DataContract]
	public class Lookup : ILookup
	{
		#region [ Fields ]

		public Result Result { get; set; }

		public string InputId { get; set; }

		[DataMember(Name = "city")]
		public string City { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }

		[DataMember(Name = "zipcode")]
		public string ZipCode { get; set; }

		[DataMember(Name = "compatibility")]
		public string Compatibility { get; set; }

		[DataMember(Name = "custom_param_dict")]
		public Dictionary<string, string> CustomParamDict = new Dictionary<string, string>{};

		#endregion

		#region [ Constructors ]

		public Lookup()
		{
			this.Result = new Result();
		}

		public Lookup(string zipcode) : this()
		{
			this.ZipCode = zipcode;
		}

		public Lookup(string city, string state) : this()
		{
			this.City = city;
			this.State = state;
		}

		public Lookup(string city, string state, string zipcode) : this()
		{
			this.City = city;
			this.State = state;
			this.ZipCode = zipcode;
		}

		public Lookup(string city, string state, string zipcode, string compatibility) : this()
		{
			this.City = city;
			this.State = state;
			this.ZipCode = zipcode;
			this.Compatibility = compatibility;
		}

		#endregion

		public void AddCustomParameter(string parameter, string value) {
			CustomParamDict.Add(parameter, value);
		}
	}
}