namespace SmartyStreets.InternationalPostalCodeApi
{
	using System;

	/// <summary>
	///     When not set, results are returned using the Latin character set. When set to Native (JPN only)
	///     results are returned in the native character set for that country. When set to Latin the results
	///     will always be provided using the Latin character set with accents and other diacritics removed.
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
