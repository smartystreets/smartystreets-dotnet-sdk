namespace SmartyStreets
{
	using System;
	using System.IO;
	using System.Net;

	public class NativeSender : ISender
	{
		private static readonly Version AssemblyVersion = typeof(NativeSender).Assembly.GetName().Version;
		private static readonly string UserAgent = string.Format("smartystreets (sdk:dotnet@{0}.{1}.{2})", AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);
		private readonly TimeSpan timeout;
        private readonly Proxy smartyProxy;

		public NativeSender()
		{
			this.timeout = TimeSpan.FromSeconds(10);
		}
		public NativeSender(TimeSpan timeout, Proxy proxy)
		{
			this.timeout = timeout;
            this.smartyProxy = proxy;
		}

		public Response Send(Request request)
		{
			var frameworkRequest = this.BuildRequest(request);
			CopyHeaders(request, frameworkRequest);

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
			frameworkRequest.Method = request.Method;

            if (this.smartyProxy != null)
                this.SetProxy(frameworkRequest);

			return frameworkRequest;
		}

        private void SetProxy(WebRequest frameworkRequest)
        {
            var proxy = new WebProxy();
            var proxyUri = new Uri(this.smartyProxy.Address);
            proxy.Address = proxyUri;

            if (this.smartyProxy.Username != null && this.smartyProxy.Password != null)
                proxy.Credentials = new NetworkCredential(this.smartyProxy.Username, this.smartyProxy.Password);

            frameworkRequest.Proxy = proxy;
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
				source.CopyTo(target);
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