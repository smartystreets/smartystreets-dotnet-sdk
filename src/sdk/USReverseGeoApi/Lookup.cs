using System;
using System.Collections.Generic;

namespace SmartyStreets.USReverseGeoApi
{

	/// <summary>
	///     In addition to holding all of the input data for this lookup, this class also
	///     will contain the result of the lookup after it comes back from the API.
	/// </summary>
	public class Lookup
	{
		#region [ Fields ]

		public SmartyResponse SmartyResponse { get; set; }

		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Source { get; set; }
		public Dictionary<string, string> CustomParamDict = new Dictionary<string, string>{};

		#endregion

		#region [ Constructors ]

		public Lookup(double latitude, double longitude)
		{
			this.Latitude = latitude.ToString("0.00000000");
			this.Longitude = longitude.ToString("0.00000000");
		}

		#endregion

		public void AddCustomParameter(string parameter, string value) {
			CustomParamDict.Add(parameter, value);
		}
	}
}