namespace SmartyStreets
{
	using System;
	using System.Collections.Generic;

	public class Request
	{
		private string urlPrefix;
		private readonly Dictionary<string, string> parameters;
		private byte[] payload;

		public string ContentType { get; set; }
		public Dictionary<string, string> Headers { get; }
		public string Method { get; private set; }

		public byte[] Payload
		{
			get => this.payload;
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

			this.parameters[name] = value;
		}

		public void SetUrlPrefix(string value)
		{
			this.urlPrefix = value;
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
				return Uri.EscapeDataString(value);
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}