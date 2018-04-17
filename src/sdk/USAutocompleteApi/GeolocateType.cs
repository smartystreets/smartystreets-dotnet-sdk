namespace SmartyStreets.USAutocompleteApi
{
	/// <summary>
	///     This class corresponds to the geolocate and geolocate_precision fields in the US Autocomplete API
	/// </summary>
	/// <remarks>See "https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields"</remarks>
	public static class GeolocateType
	{
		public const string CITY = "city";
		public const string STATE = "state";
		public const string NONE = "null";
	}
}