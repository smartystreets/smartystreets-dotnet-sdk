using System;

namespace SmartyStreets
{
	using System.Collections.Generic;
	using System.Web;

	public class Request
	{
		private string urlPrefix;
		private readonly Dictionary<string, string> parameters;
		private byte[] payload;

		public string ContentType { get; set; }
		public Dictionary<string, string> Headers { get; }
		public string Method { get; set; }
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
			this.Headers = new Dictionary<string, string>();
			this.parameters = new Dictionary<string, string>();
			this.urlPrefix = "";
		}

		public void SetHeader(string header, string value)
		{
			this.Headers[header] = value;
		}
		public void SetParameter(string name, string value)
		{
			if (name == null || value == null || name.Length == 0 || value.Length == 0)
				return;

			var valueLength = "value length: " + value.Length;
			var valueLength2 = "value length2: " + value.Length;

			this.parameters[name] = value;
		}

		public void SetUrlPrefix(string urlPrefix)
		{
			this.urlPrefix = urlPrefix;
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
		private static string UrlEncode(string value)
		{
			try
			{
				return HttpUtility.UrlEncode(value);
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}