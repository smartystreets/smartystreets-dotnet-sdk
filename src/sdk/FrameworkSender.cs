using System;
using System.Net;
using System.IO;

namespace SmartyStreets
{
	public class FrameworkSender : ISender
	{
		private TimeSpan timeout;

		public FrameworkSender()
		{
			this.timeout = TimeSpan.FromSeconds(10);
		}

		public FrameworkSender(TimeSpan timeout)
		{
			this.timeout = timeout;
		}

		public Response Send(Request request)
		{
			var frameworkRequest = this.BuildRequest(request);

			TryWritePayload(request, frameworkRequest);

			var frameworkResponse = GetResponse(frameworkRequest);
			var statusCode = (int)frameworkResponse.StatusCode;
			var payload = GetResponseBody(frameworkResponse);

			return new Response(statusCode, payload);
		}

		private HttpWebRequest BuildRequest(Request request)
		{
			var frameworkRequest = (HttpWebRequest)WebRequest.Create(request.GetUrl());
			frameworkRequest.Timeout = (int)this.timeout.TotalMilliseconds;
			return frameworkRequest;
		}

		private static void TryWritePayload(Request request, HttpWebRequest frameworkRequest)
		{
			if (request.Method == "POST")
				using (var sourceStream = new MemoryStream(request.Payload))
					CopyStream(sourceStream, GetRequestStream(frameworkRequest));
		}

		private static void CopyStream(Stream source, Stream target)
		{
			try
			{
				source.CopyTo(target);
			}
			catch (IOException)
			{
				throw new SmartyException();
			}
		}

		private static Stream GetRequestStream(HttpWebRequest request)
		{
			try
			{
				return request.GetRequestStream();
				
			}
			catch (WebException)
			{
				throw new SmartyException();
			}
		}

		private static HttpWebResponse GetResponse(HttpWebRequest request)
		{
			try
			{
				return (HttpWebResponse)request.GetResponse();
			}
			catch (WebException e)
			{
				if (e.Response == null)
					throw;

				return (HttpWebResponse)e.Response;
			}
		}

		private static byte[] GetResponseBody(HttpWebResponse response)
		{
			if (response.ContentLength <= 0)
				return null;


			using (var targetStream = new MemoryStream((int)response.ContentLength))
			using (var responseStream = response.GetResponseStream())
			{
				CopyStream(responseStream, targetStream);
				return targetStream.ToArray();
			}
		}
	}
}