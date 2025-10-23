﻿using System.Runtime.CompilerServices;

namespace SmartyStreets.USStreetApi
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	[DataContract]
	public class Lookup : ILookup
	{
		#region [ Fields ]

		public const string STRICT = "strict";
		public const string ENHANCED = "enhanced";
		public const string INVALID = "invalid";

		public const string DEFAULT_FORMAT = "default";
		public const string PROJECT_USA_FORMAT = "project-usa";

		public const string POSTAL = "postal";
		public const string GEOGRAPHIC = "geographic";
		
		public List<Candidate> Result { get; private set; }

        [DataMember(Name = "input_id")]
		public string InputId { get; set; }

		[DataMember(Name = "street")]
		public string Street { get; set; }

		[DataMember(Name = "street2")]
		public string Street2 { get; set; }

		[DataMember(Name = "secondary")]
		public string Secondary { get; set; }

		[DataMember(Name = "city")]
		public string City { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }

		[DataMember(Name = "zipcode")]
		public string ZipCode { get; set; }

		[DataMember(Name = "lastline")]
		public string Lastline { get; set; }

		[DataMember(Name = "addressee")]
		public string Addressee { get; set; }

		[DataMember(Name = "urbanization")]
		public string Urbanization { get; set; }

		[DataMember(Name = "candidates")]
		private int maxCandidates;

		[DataMember(Name = "match")]
		public string MatchStrategy { get; set; }

		[DataMember(Name = "format")]
		public string OutputFormat { get; set; }
		
		[DataMember(Name = "compatibility")]
		public string Compatibility { get; set; }

		[DataMember(Name = "county_source")]
		public string CountySource { get; set; }

		[DataMember(Name = "custom_param_dict")]
		public Dictionary<string, string> CustomParamDict = new Dictionary<string, string>{};

		public int MaxCandidates
		{
			get => this.maxCandidates;
			set
			{
				if (value > 0)
					this.maxCandidates = value;
				else
					throw new ArgumentOutOfRangeException(nameof(value), "Max candidates must be a positive integer.");
			}
		}

		#endregion

		#region [ Constructors ]

		public Lookup()
		{
			this.maxCandidates = 1;
			this.Result = new List<Candidate>();
		}

		public Lookup(string freeformAddress) : this()
		{
			this.Street = freeformAddress;
		}

		#endregion

		public void AddToResult(Candidate newCandidate)
		{
			this.Result.Add(newCandidate);
		}

		public void AddCustomParameter(string parameter, string value) {
			CustomParamDict.Add(parameter, value);
		}
	}
}