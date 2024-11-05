namespace SmartyStreets.InternationalAutocompleteApi
{
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	///     In addition to holding all of the input data for this lookup, this class also
	///     will contain the result of the lookup after it comes back from the API.
	/// </summary>
	/// <remarks>
	///     See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields"
	/// </remarks>
	public class Lookup
	{
		#region [ Fields ]

		private const int MAX_RESULTS_DEFAULT = 10;
		
		public Candidate[] Result { get; set; }
		public string Search { get; set; }
		public string Country { get; set; }
		public string AddressID {get; set; }
		public int MaxResults { get; set; }
		public string Locality { get; set; }
		public string PostalCode { get; set; }
		public Dictionary<string, string> CustomParamDict = new Dictionary<string, string>{};

		#endregion

		#region [ Constructors ]

		/// <remarks>
		///     If you use this constructor, don't forget to set the Prefix field. It is required.
		/// </remarks>
		/// >
		public Lookup()
		{
			this.MaxResults = MAX_RESULTS_DEFAULT;
		}

		/// <param name="search">The beginning of an address.</param>
		public Lookup(string search) : this()
		{
			this.Search = search;
		}

		#endregion
		
		internal string MaxSuggestionsString => this.MaxResults.Equals(MAX_RESULTS_DEFAULT) ? null : this.MaxResults.ToString();

		public void AddCustomParameter(string parameter, string value) {
			CustomParamDict.Add(parameter, value);
		}
	}
}