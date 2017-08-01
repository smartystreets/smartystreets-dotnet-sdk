using System.Collections;

namespace SmartyStreets.USAutocompleteApi
{
    /// <summary>
    /// In addition to holding all of the input data for this lookup, this class also
    /// will contain the result of the lookup after it comes back from the API.
    /// </summary>
    /// <remarks>
    /// See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields"
    /// </remarks>
    public class Lookup
    {
		#region [ Fields ]

		private const double PREFER_RATIO_DEFAULT = 1 / 3.0;
		private const int MAX_SUGGESTIONS_DEFAULT = 10;
        public Suggestion[] Result { get; set; }
        public string Prefix { get; set; }
        public int MaxSuggestions { get; set; }
        public ArrayList CityFilter { get; set; }
        public ArrayList StateFilter { get; set; }
        public ArrayList Prefer { get; set; }
        public string GeolocateType { get; set; }
        public double PreferRatio { get; set; }

        #endregion

        #region [ Constructors ]

        /// <remarks>
        /// If you use this constructor, don't forget to set the Prefix field. It is required.
        /// </remarks>>
        public Lookup()
        {
            this.MaxSuggestions = MAX_SUGGESTIONS_DEFAULT;
            this.GeolocateType = USAutocompleteApi.GeolocateType.CITY;
            this.CityFilter = new ArrayList();
            this.StateFilter = new ArrayList();
            this.Prefer = new ArrayList();
            this.PreferRatio = PREFER_RATIO_DEFAULT;
        }

        /// <param name="prefix">The beginning of an address.</param>
        public Lookup(string prefix) : this()
        {
            this.Prefix = prefix;
        }

        internal string GetPreferRatioStringIfSet() {
            if (this.PreferRatio.Equals(PREFER_RATIO_DEFAULT))
                return null;
            return this.PreferRatio.ToString();
        }

        internal string GetMaxSuggestionsStringIfSet() {
            if (this.MaxSuggestions.Equals(MAX_SUGGESTIONS_DEFAULT))
                return null;
            return this.MaxSuggestions.ToString();
        }

        #endregion

        public void AddCityFilter(string city) {
            this.CityFilter.Add(city);
        }

        public void AddStateFilter(string stateAbbreviation) {
            this.StateFilter.Add(stateAbbreviation);
        }

        public void AddPrefer(string cityOrState) {
            this.Prefer.Add(cityOrState);
        }
    }
}