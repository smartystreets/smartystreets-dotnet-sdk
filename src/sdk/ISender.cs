using System;
using System.Net;

namespace SmartyStreets
{
	public interface ISender
	{
		HttpWebResponse Send(HttpWebRequest request);
	}
}