namespace SmartyStreets
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class NativeSenderTests
    {
        [Test]
        public void NullInjectedHttpClient_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new NativeSender((HttpClient)null));
        }

        [Test]
        public void Dispose_DoesNotDisposeInjectedHttpClient()
        {
            var handler = new RecordingHandler();
            var httpClient = new HttpClient(handler);
            var sender = new NativeSender(httpClient);

            sender.Dispose();

            // If the client was disposed, sending would throw ObjectDisposedException.
            Assert.DoesNotThrow(() =>
                httpClient.GetAsync("https://example.smarty.com/").GetAwaiter().GetResult());
        }

        [Test]
        public void InjectedHttpClient_AddsSdkUserAgentPerRequest()
        {
            var handler = new RecordingHandler();
            var httpClient = new HttpClient(handler);
            var sender = new NativeSender(httpClient);

            var request = new Request();
            request.SetUrlPrefix("https://example.smarty.com/");
            sender.Send(request);

            Assert.That(handler.LastRequest.Headers.UserAgent.ToString(), Does.Contain("smartystreets"));
            // Client defaults must remain untouched.
            Assert.That(httpClient.DefaultRequestHeaders.UserAgent, Is.Empty);
        }

        [Test]
        public void InjectedHttpClient_DoesNotOverrideCallerUserAgent()
        {
            var handler = new RecordingHandler();
            var httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("caller-ua/1.0");
            var sender = new NativeSender(httpClient);

            var request = new Request();
            request.SetUrlPrefix("https://example.smarty.com/");
            sender.Send(request);

            // HttpClient merges DefaultRequestHeaders into the outgoing request, so the caller's
            // UA shows up on the handler's request. The key check: we didn't stack our SDK UA
            // on top — only the caller's UA is present.
            var ua = handler.LastRequest.Headers.UserAgent.ToString();
            Assert.That(ua, Is.EqualTo("caller-ua/1.0"));
            Assert.That(ua, Does.Not.Contain("smartystreets"));
        }

        [Test]
        public void Dispose_DisposesOwnedHttpClient()
        {
            var sender = new NativeSender();
            var field = typeof(NativeSender).GetField("client", BindingFlags.NonPublic | BindingFlags.Instance);
            var inner = (HttpClient)field.GetValue(sender);

            sender.Dispose();

            Assert.Throws<ObjectDisposedException>(() =>
                inner.GetAsync("https://example.smarty.com/").GetAwaiter().GetResult());
        }

        [Test]
        public void Dispose_IsIdempotent()
        {
            var sender = new NativeSender(new HttpClient(new RecordingHandler()));
            sender.Dispose();
            Assert.DoesNotThrow(() => sender.Dispose());
        }

        private sealed class RecordingHandler : HttpMessageHandler
        {
            public HttpRequestMessage LastRequest { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                LastRequest = request;
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(new byte[0])
                };
                return Task.FromResult(response);
            }
        }
    }
}
