namespace SmartyStreets.InternationalPostalCodeApi
{
	using System.Collections.Generic;

	/// <summary>
	///     In addition to holding all of the input data for this lookup, this class also
	///     will contain the result of the lookup after it comes back from the API.
	/// </summary>
	/// <remarks>
	///     Lookups must have certain required fields set with non-blank values.
	///     These can be found at "https://smartystreets.com/docs/cloud/international-postal-code-api"
	/// </remarks>
	public class Lookup : ILookup
	{
		#region [ Fields ]

		public List<Candidate> Result { get; private set; }

		public string InputId { get; set; }
		public string Country { get; set; }

		/// <remarks>
		///     May be set to LanguageMode.Native or LanguageMode.Latin
		/// </remarks>
		public LanguageMode? Language { get; set; }

		public string Locality { get; set; }
		public string AdministrativeArea { get; set; }
		public string PostalCode { get; set; }

		/// <remarks>
		///     Only sent when greater than zero.
		/// </remarks>
		public int MaxResults { get; set; }
		public Dictionary<string, string> CustomParamDict = new Dictionary<string, string>{};

		#endregion

		#region [ Constructors ]

		public Lookup()
		{
			this.Result = new List<Candidate>();
		}

		#endregion

		public void AddToResult(Candidate newCandidate)
		{
			this.Result.Add(newCandidate);
		}

		public void AddCustomParameter(string parameter, string value)
		{
			CustomParamDict.Add(parameter, value);
		}
	}
}

