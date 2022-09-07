namespace SmartyStreets
{
	using System;
	using System.IO;
	using System.Net;

	public class NativeSender : ISender
	{
		private static readonly Version AssemblyVersion = typeof(NativeSender).Assembly.GetName().Version;

		private static readonly string UserAgent = string.Format("smartystreets (sdk:dotnet@{0}.{1}.{2})",
			AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);

		private readonly TimeSpan timeout;
		private readonly IWebProxy proxy;

		public NativeSender()
		{
			this.timeout = TimeSpan.FromSeconds(10);
		}

		public NativeSender(TimeSpan timeout, Proxy proxy = null) : this()
		{
			this.timeout = timeout;
			this.proxy = (proxy ?? new Proxy()).NativeProxy;
		}

		public Response Send(Request request)
		{
			var frameworkRequest = this.BuildRequest(request);
			CopyHeaders(request, frameworkRequest);

			TryWritePayload(request, frameworkRequest);

			var frameworkResponse = GetResponse(frameworkRequest);
			var statusCode = (int)frameworkResponse.StatusCode;
			var payload = GetResponseBody(frameworkResponse);

			var retVal = new Response(statusCode, payload);
			if (statusCode == 429)
			{
				string retryValue = frameworkResponse.Headers.Get("Retry-After");
				if ((retryValue != null) && (retryValue.Length != 0))
				{
					retVal.HeaderInfo.Add("Retry-After", retryValue);
				}
			}

			return retVal;
		}

		private HttpWebRequest BuildRequest(Request request)
		{
			var frameworkRequest = (HttpWebRequest)WebRequest.Create(request.GetUrl());
			frameworkRequest.Timeout = (int)this.timeout.TotalMilliseconds;
			frameworkRequest.Method = request.Method;
			frameworkRequest.Proxy = this.proxy;
			frameworkRequest.AutomaticDecompression = DecompressionMethods.GZip;
			return frameworkRequest;
		}

		private static void CopyHeaders(Request request, HttpWebRequest frameworkRequest)
		{
			foreach (var item in request.Headers)
				if (item.Key == "Referer")
					frameworkRequest.Referer = item.Value;
				else
					frameworkRequest.Headers.Add(item.Key, item.Value);

			frameworkRequest.UserAgent = UserAgent;
		}

		private static void TryWritePayload(Request request, WebRequest frameworkRequest)
		{
			if (request.Method != "POST" || request.Payload == null)
				return;

			using (var sourceStream = new MemoryStream(request.Payload))
				CopyStream(sourceStream, GetRequestStream(frameworkRequest));
		}

		private static void CopyStream(Stream source, Stream target)
		{
			try
			{
#if NET35
			    byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
			    int bytesRead;

			    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
			    {
			        target.Write(buffer, 0, bytesRead);
			    }
#else
				source.CopyTo(target);
#endif
			}
			catch (IOException ex)
			{
				throw new SmartyException("Unable to write to request stream.", ex);
			}
		}

		private static Stream GetRequestStream(WebRequest request)
		{
			try
			{
				return request.GetRequestStream();
			}
			catch (WebException ex)
			{
				throw new SmartyException("Failed to make request.", ex);
			}
		}

		private static HttpWebResponse GetResponse(WebRequest request)
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

		private static byte[] GetResponseBody(WebResponse response)
		{
			var length = response.ContentLength >= 0 ? (int)response.ContentLength : 0;

			using (var targetStream = new MemoryStream(length))
			using (var responseStream = response.GetResponseStream())
			{
				CopyStream(responseStream, targetStream);
				return targetStream.ToArray();
			}
		}
	}
}