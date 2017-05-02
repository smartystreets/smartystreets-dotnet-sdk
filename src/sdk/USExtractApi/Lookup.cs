namespace SmartyStreets.USExtractApi
{
	using System;
	/// <summary>
	/// In addition to holding all of the input data for this lookup, this class also<br>
	/// will contain the result of the lookup after it comes back from the API.
	/// </summary>
	/// <remarks>See "https://smartystreets.com/docs/cloud/us-extract-api#http-request-input-fields"</remarks>
	public class Lookup
	{
		#region [ Fields ]

		private Result Result { get; set; }
		private string Html { get; set; }
		private bool Aggressive { get; set; }
		private bool AddressesHaveLineBreaks { get; set; }
		private int AddressesPerLine { get; set; }
		private string Text { get; set; }

		#endregion

		#region [ Constructors ]
		public Lookup()
		{
            this.Result = new Result();
        	this.AddressesHaveLineBreaks = true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:SmartyStreets.USExtractApi.Lookup"/> class.
		/// </summary>
		/// <param name="text">The text that is to have addresses extracted out of it for verification</param>
		public Lookup(string text) : this()
		{
			this.Text = text;
		}

		#endregion
	}
}
