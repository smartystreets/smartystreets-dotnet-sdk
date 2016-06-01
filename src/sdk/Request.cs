using System;
using SmartyStreets;
using System.Collections.Generic;
using System.Security.Policy;

namespace SmartyStreets
{
	public class Request
	{

		private Dictionary<string, string> parameters;
		private string urlPrefix;

		public Request()
		{
			this.parameters = new Dictionary<string, string>();
		}

		public Request(string urlPrefix) : this()
		{
			this.urlPrefix = urlPrefix;
		}

		public void PutParameter(string name, string value)
		{
			if (name == null || value == null || name.Length == 0)
				return;

			this.parameters.Add(name, value);
		}

		public string GetUrl()
		{
			string url = this.urlPrefix;

			if (!url.Contains("?"))
				url += "?";

			foreach (string key in parameters.Keys)
			{
				if (!url.EndsWith("?"))
					url += "&";

				url += key + "=";
			}

			return url;
		}
	}
}

