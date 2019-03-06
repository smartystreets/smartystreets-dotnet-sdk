namespace SmartyStreets
{
	using System;
	using System.IO;
	using System.Net;
    using System.Threading.Tasks;

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

		public async Task<Response> SendAsync(Request request)
		{
			var frameworkRequest = this.BuildRequest(request);
			CopyHeaders(request, frameworkRequest);

			await TryWritePayloadAsync(request, frameworkRequest);

			var frameworkResponse = await GetResponseAsync(frameworkRequest);
			var statusCode = (int)frameworkResponse.StatusCode;
			var payload = await GetResponseBodyAsync(frameworkResponse);

			return new Response(statusCode, payload);
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

		private static async Task TryWritePayloadAsync(Request request, WebRequest frameworkRequest)
		{
			if (request.Method != "POST" || request.Payload == null)
				return;

			using (var sourceStream = new MemoryStream(request.Payload))
				await CopyStreamAsync(sourceStream, GetRequestStream(frameworkRequest));
		}

		private static async Task CopyStreamAsync(Stream source, Stream target)
		{
			try
			{
				await source.CopyToAsync(target);
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

		private static async Task<HttpWebResponse> GetResponseAsync(WebRequest request)
		{
			try
			{
				return (HttpWebResponse) await request.GetResponseAsync();
			}
			catch (WebException e)
			{
				if (e.Response == null)
					throw;

				return (HttpWebResponse)e.Response;
			}
		}

		private static async Task<byte[]> GetResponseBodyAsync(WebResponse response)
		{
			var length = response.ContentLength >= 0 ? (int)response.ContentLength : 0;

			using (var targetStream = new MemoryStream(length))
			using (var responseStream = response.GetResponseStream())
			{
				await CopyStreamAsync(responseStream, targetStream);
				return targetStream.ToArray();
			}
		}
	}
}