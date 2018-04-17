namespace SmartyStreets.InternationalStreetApi
{
	/// <summary>
	///     When not set, the output language will match the language of the input values. When set to NATIVE the
	///     results will always be in the language of the output country. When set to LATIN the results
	///     will always be provided using a Latin character set.
	/// </summary>
	public static class LanguageMode
	{
		public const string NATIVE = "native";
		public const string LATIN = "latin";
	}
}