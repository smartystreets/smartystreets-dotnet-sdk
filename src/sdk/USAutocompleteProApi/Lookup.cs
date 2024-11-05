using SmartyStreets.USAutocompleteApi;

namespace SmartyStreets.USAutocompleteProApi
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

		private const double PREFER_RATIO_DEFAULT = 3;
		private const int MAX_RESULTS_DEFAULT = 10;
		public Suggestion[] Result { get; set; }
		public string Search { get; set; }
		public int MaxResults { get; set; }
		public ArrayList CityFilter { get; set; }
		public ArrayList StateFilter { get; set; }
		public ArrayList ZIPFilter { get; set; }
		public ArrayList ExcludeStates { get; set; }
		public ArrayList PreferCities { get; set; }
		public ArrayList PreferStates { get; set; }
		public ArrayList PreferZIPCodes { get; set; }	
		public double PreferRatio { get; set; }
		public string PreferGeolocation { get; set; }
		public string Selected { get; set; }
		public string Source { get; set; }
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
			this.CityFilter = new ArrayList();
			this.StateFilter = new ArrayList();
			this.ZIPFilter = new ArrayList();
			this.ExcludeStates = new ArrayList();
			this.PreferCities = new ArrayList();
			this.PreferStates = new ArrayList();
			this.PreferZIPCodes = new ArrayList();
			this.PreferRatio = PREFER_RATIO_DEFAULT;
			this.PreferGeolocation = GeolocateType.CITY;
		}

		/// <param name="prefix">The beginning of an address.</param>
		public Lookup(string search) : this()
		{
			this.Search = search;
		}

		internal string GetPreferRatioStringIfSet()
		{
			if (this.PreferRatio.Equals(PREFER_RATIO_DEFAULT))
				return null;
			return this.PreferRatio.ToString();
		}

		internal string GetMaxSuggestionsStringIfSet()
		{
			if (this.MaxResults.Equals(MAX_RESULTS_DEFAULT))
				return null;
			return this.MaxResults.ToString();
		}

		#endregion

		public void AddCityFilter(string city)
		{
			this.CityFilter.Add(city);
		}

		public void AddStateFilter(string stateAbbreviation)
		{
			this.StateFilter.Add(stateAbbreviation);
		}

		public void AddZIPFilter(string zipcode)
		{
			this.PreferGeolocation = GeolocateType.NONE;
			this.ZIPFilter.Add(zipcode);
		}

		public void AddExclusion(string stateAbbreviation)
		{
			this.ExcludeStates.Add(stateAbbreviation);
		}

		public void AddPreferCity(string city)
		{
			this.PreferCities.Add(city);
		}

		public void AddPreferState(string stateAbbreviation)
		{
			this.PreferStates.Add(stateAbbreviation);
		}

		public void AddPreferZIP(string zipcode)
		{
			this.PreferGeolocation = GeolocateType.NONE;
			this.PreferZIPCodes.Add(zipcode);
		}

		public void AddCustomParameter(string parameter, string value) {
			CustomParamDict.Add(parameter, value);
		}
	}
}