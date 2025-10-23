﻿using System.Collections.Generic;

namespace SmartyStreets
{
	public class Response
	{
		public int StatusCode { get; }
		public byte[] Payload { get; }
		
		public Dictionary<string, string> HeaderInfo { get; }

		public Response(int statusCode, byte[] payload)
		{
			this.StatusCode = statusCode;
			this.Payload = payload;
			HeaderInfo = new Dictionary<string, string>();
		}
	}
}