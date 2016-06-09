using System.Collections.Generic;
using System.Net;

namespace SmartyStreets
{
	public class Request
	{
		private string urlPrefix;
		private byte[] payload;
		private readonly Dictionary<string, string> headers;
		private readonly Dictionary<string, string> parameters;

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

		private string UrlEncode(string value)
		{
			try {
				return WebUtility.UrlEncode(value);
			} catch {
				return "";
			}
		}

		public string GetUrl()
		{
			string url = this.urlPrefix;

			if (!url.Contains("?"))
				url += "?";

			foreach (var pair in parameters)
			{
				if (!url.EndsWith("?"))
					url += "&";

				string encodedName = this.UrlEncode(pair.Key);
				string encodedValue = this.UrlEncode(pair.Value);
				url += encodedName + "=" + encodedValue;
			}

			return url;
		}
	}
}

