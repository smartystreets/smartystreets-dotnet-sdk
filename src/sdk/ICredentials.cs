using System;
using System.Net.Cache;
using System.Net;

namespace SmartyStreets
{
	public interface ICredentials
	{
		void Sign(HttpWebRequest request);
	}
}