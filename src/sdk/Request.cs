namespace SmartyStreets
{
	using System.Collections.Generic;
	using System.Web;

	public class Request
	{
		private readonly string urlPrefix;
		private readonly Dictionary<string, string> headers;
		private readonly Dictionary<string, string> parameters;
		private byte[] payload;

		public Dictionary<string, string> Headers { get {return this.headers;} }

		public string Method { get; private set; }

		public byte[] Payload
		{
			get { return this.payload; }
			set
			{
				this.payload = value;
				this.Method = "POST";
			}
		}

		public Request()
		{
			this.Method = "GET";
			this.headers = new Dictionary<string, string>();
			this.parameters = new Dictionary<string, string>();
		}

		public Request(string urlPrefix) : this()
		{
			this.urlPrefix = urlPrefix;
		}

		public void SetHeader(string header, string value)
		{
			this.headers[header] = value;
		}

		public void SetParameter(string name, string value)
		{
			if (name == null || value == null || name.Length == 0)
				return;

			this.parameters[name] = value;
		}

		private static string UrlEncode(string value)
		{
			try {
				return HttpUtility.UrlEncode(value);
			}
			catch
			{
				return string.Empty;
			}
		}

		public string GetUrl()
		{
			var url = this.urlPrefix;

			if (!url.Contains("?"))
				url += "?";

			foreach (var pair in this.parameters)
			{
				if (!url.EndsWith("?"))
					url += "&";

				var encodedName = UrlEncode(pair.Key);
				var encodedValue = UrlEncode(pair.Value);
				url += encodedName + "=" + encodedValue;
			}

			return url;
		}
	}
}
