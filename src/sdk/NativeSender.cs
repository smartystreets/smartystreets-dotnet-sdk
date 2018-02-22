namespace SmartyStreets
{
	using System;
	using System.Net;
	using System.Net.Http;

	public class NativeSender : ISender
	{
		private static readonly Version AssemblyVersion = typeof(NativeSender).Assembly.GetName().Version;
		private static readonly string UserAgent = string.Format("smartystreets (sdk:dotnet@{0}.{1}.{2})", AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);
		private HttpClient httpClient;

		public NativeSender()
		{
			BuildClient(TimeSpan.FromSeconds(10));
		}

		public NativeSender(TimeSpan timeout, Proxy proxy)
		{
			BuildClient(timeout, proxy);
		}

		public Response Send(Request request)
		{
			using (var frameworkRequest = BuildRequest(request)) {
				CopyHeaders(request, frameworkRequest);

				TryWritePayload(request, frameworkRequest);

				using (var frameworkResponse = GetResponse(frameworkRequest)) {
					var statusCode = (int)frameworkResponse.StatusCode;
					var payload = GetResponseBody(frameworkResponse);

					return new Response(statusCode, payload);
				}
			}
		}

		private void BuildClient(TimeSpan timeout, Proxy smartyProxy = null)
		{
			HttpClientHandler handler = null;
			if (smartyProxy != null) {
				handler = new HttpClientHandler();
				var proxy = new WebProxy(smartyProxy.Address);

				if (smartyProxy.Username != null && smartyProxy.Password != null) {
					proxy.Credentials = new NetworkCredential(smartyProxy.Username, smartyProxy.Password);
				}

				handler.Proxy = proxy;
				httpClient = new HttpClient(handler);
			}
			else {
				httpClient = new HttpClient();
			}
			httpClient.Timeout = timeout;
		}

		private HttpRequestMessage BuildRequest(Request request)
		{
			var frameworkRequest = new HttpRequestMessage(new HttpMethod(request.Method), request.GetUrl());

			return frameworkRequest;
		}

		private static void CopyHeaders(Request request, HttpRequestMessage frameworkRequest)
		{
			foreach (var item in request.Headers) {
				if (item.Key == "Referer")
					frameworkRequest.Headers.Referrer = new Uri(item.Value);
				else
					frameworkRequest.Headers.Add(item.Key, item.Value);
			}

			frameworkRequest.Headers.UserAgent.ParseAdd(UserAgent);
		}

		private static void TryWritePayload(Request request, HttpRequestMessage frameworkRequest)
		{
			if (request.Method == "POST" && request.Payload != null)
				frameworkRequest.Content = new ByteArrayContent(request.Payload);
		}

		private HttpResponseMessage GetResponse(HttpRequestMessage request)
		{
			return httpClient.SendAsync(request).Result;
		}

		private static byte[] GetResponseBody(HttpResponseMessage response)
		{
			return response.Content.ReadAsByteArrayAsync().Result;
		}
	}
}
