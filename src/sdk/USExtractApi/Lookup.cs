namespace SmartyStreets.USExtractApi
{
	/// <summary>
	///     In addition to holding all of the input data for this lookup, this class also
	///     will contain the result of the lookup after it comes back from the API.
	/// </summary>
	/// <remarks>See "https://smartystreets.com/docs/cloud/us-extract-api#http-request-input-fields"</remarks>
	public class Lookup
	{
		#region [ Fields ]
		
		public const string STRICT = "strict";
		public const string ENHANCED = "enhanced";
		public const string INVALID = "invalid";

		private string html;
		public Result Result { get; set; }
		public bool IsAggressive { get; set; }
		public bool AddressesHaveLineBreaks { get; set; }
		public int AddressesPerLine { get; set; }
		public string MatchStrategy { get; set; }
		public string Text { get; set; }

		#endregion

		#region [ Constructors ]

		public Lookup()
		{
			this.Result = new Result();
			this.AddressesHaveLineBreaks = true;
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="T:SmartyStreets.USExtractApi.Lookup" /> class.
		/// </summary>
		/// <param name="text">The text that is to have addresses extracted out of it for verification</param>
		public Lookup(string text) : this()
		{
			this.Text = text;
		}

		#endregion

		public string IsHtml()
		{
			return this.html;
		}

		public void SpecifyHtmlInput(bool html)
		{
			this.html = html.ToString().ToLower();
		}
	}
}