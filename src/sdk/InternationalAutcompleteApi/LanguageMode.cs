namespace SmartyStreets.InternationalAutocompleteApi
{
	using System;

	/// <summary>
	///     When not set, the output language will match the default for the country. When set to Native the
	///     results will always be in the language of the output country whenever possible. Note: For French
	///     diacritics in Canada, you must specify Native. When set to Latin the results will always be
	///     provided using the Latin character set with accents and other diacritics removed.
	/// </summary>
	public enum LanguageMode
	{
		Native,
		Latin
	}

	public static class LanguageModeExtensions
	{
		internal static string ToWireValue(this LanguageMode mode)
		{
			switch (mode)
			{
				case LanguageMode.Native:
					return "native";
				case LanguageMode.Latin:
					return "latin";
				default:
					throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
			}
		}

		/// <summary>
		///     Resolves a value (eg. from external config) into a LanguageMode, matching "native"/"latin"
		///     regardless of case.
		/// </summary>
		public static LanguageMode FromValue(string value)
		{
			if (string.Equals(value, "native", StringComparison.OrdinalIgnoreCase))
				return LanguageMode.Native;
			if (string.Equals(value, "latin", StringComparison.OrdinalIgnoreCase))
				return LanguageMode.Latin;

			throw new UnprocessableEntityException(
				"invalid Language value; must be unset, 'native', or 'latin' (case-insensitive)");
		}
	}
}
