using System;
using System.Net;

namespace SmartyStreets
{
	public class StaticCredentials : ICredentials
	{
		private string authId;
		private string authToken;

		public StaticCredentials(string authId, string authToken)
		{
			this.authId = authId;
			this.authToken = authToken;
		}

		public void Sign(HttpWebRequest request)
		{


//
//			request.RequestUri.Query.Insert(0, this.authId);
//			request.RequestUri.Query.Insert(0, this.authToken);
		}
	}
}