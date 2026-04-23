using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SmartyStreets
{
    using NUnit.Framework;

    [TestFixture]
    public class ClientBuilderTests
    {
        private static Dictionary<string, string> GetCustomQueries(ClientBuilder builder)
        {
            var field = typeof(ClientBuilder).GetField("customQueries", BindingFlags.NonPublic | BindingFlags.Instance);
            return (Dictionary<string, string>)field.GetValue(builder);
        }

        [Test]
        public void TestWithFeatureIanaTimeZone()
        {
            var builder = new ClientBuilder().WithFeatureIanaTimeZone();

            Assert.AreEqual("iana-timezone", GetCustomQueries(builder)["features"]);
        }

        [Test]
        public void TestWithFeatureIanaTimeZoneAndComponentAnalysis_ShouldAppend()
        {
            var builder = new ClientBuilder()
                .WithFeatureComponentAnalysis()
                .WithFeatureIanaTimeZone();

            Assert.AreEqual("component-analysis,iana-timezone", GetCustomQueries(builder)["features"]);
        }

        [Test]
        public void TestWithSender_ThrowsWhenCombinedWithMaxTimeout()
        {
            var capturingSender = new RequestCapturingSender();
            var builder = new ClientBuilder("test-id", "test-token")
                .WithSender(capturingSender)
                .WithMaxTimeout(System.TimeSpan.FromSeconds(5))
                .WithSerializer(new FakeSerializer(null));

            Assert.Throws<System.InvalidOperationException>(() => builder.BuildUsStreetApiClient());
        }

        [Test]
        public void TestWithSender_ThrowsWhenCombinedWithProxy()
        {
            var capturingSender = new RequestCapturingSender();
            var builder = new ClientBuilder("test-id", "test-token")
                .WithSender(capturingSender)
                .ViaProxy("http://localhost:8080", "", "")
                .WithSerializer(new FakeSerializer(null));

            Assert.Throws<System.InvalidOperationException>(() => builder.BuildUsStreetApiClient());
        }

        [Test]
        public void TestWithHttpClient_ThrowsWhenCombinedWithMaxTimeout()
        {
            var builder = new ClientBuilder("test-id", "test-token")
                .WithHttpClient(new HttpClient())
                .WithMaxTimeout(System.TimeSpan.FromSeconds(5))
                .WithSerializer(new FakeSerializer(null));

            Assert.Throws<System.InvalidOperationException>(() => builder.BuildUsStreetApiClient());
        }

        [Test]
        public void TestWithHttpClient_ThrowsWhenCombinedWithProxy()
        {
            var builder = new ClientBuilder("test-id", "test-token")
                .WithHttpClient(new HttpClient())
                .ViaProxy("http://localhost:8080", "", "")
                .WithSerializer(new FakeSerializer(null));

            Assert.Throws<System.InvalidOperationException>(() => builder.BuildUsStreetApiClient());
        }

        [Test]
        public void TestWithHttpClient_ThrowsWhenCombinedWithWithSender()
        {
            var builder = new ClientBuilder("test-id", "test-token")
                .WithHttpClient(new HttpClient())
                .WithSender(new RequestCapturingSender())
                .WithSerializer(new FakeSerializer(null));

            Assert.Throws<System.InvalidOperationException>(() => builder.BuildUsStreetApiClient());
        }

        [Test]
        public void TestWithHttpClient_NullThrows()
        {
            Assert.Throws<System.ArgumentNullException>(
                () => new ClientBuilder("test-id", "test-token").WithHttpClient(null));
        }

        [Test]
        public void TestWithHttpClient_InjectedClientIsUsedThroughMiddlewareChain()
        {
            var handler = new CapturingHandler();
            var httpClient = new HttpClient(handler);
            var client = new ClientBuilder("test-id", "test-token")
                .WithHttpClient(httpClient)
                .WithSerializer(new FakeSerializer(null))
                .BuildUsStreetApiClient();

            client.Send(new USStreetApi.Lookup("1 Rosedale"));

            Assert.NotNull(handler.LastRequest);
            var url = handler.LastRequest.RequestUri.ToString();
            Assert.That(url, Does.Contain("us-street.api.smarty.com"));
            Assert.That(url, Does.Contain("auth-id=test-id"));
            Assert.That(url, Does.Contain("auth-token=test-token"));
        }

        [Test]
        public void TestWithHttpClient_DisposingApiClientDoesNotDisposeInjectedHttpClient()
        {
            var handler = new CapturingHandler();
            var httpClient = new HttpClient(handler);
            var apiClient = new ClientBuilder("test-id", "test-token")
                .WithHttpClient(httpClient)
                .WithSerializer(new FakeSerializer(null))
                .BuildUsStreetApiClient();

            apiClient.Dispose();

            // Injected client must survive disposal of the API client / sender chain.
            Assert.DoesNotThrow(() =>
                httpClient.GetAsync("https://example.smarty.com/").GetAwaiter().GetResult());
        }

        [Test]
        public void TestWithSender_WrapsWithMiddlewareChain()
        {
            var capturingSender = new RequestCapturingSender();
            var client = new ClientBuilder("test-id", "test-token")
                .WithSender(capturingSender)
                .WithSerializer(new FakeSerializer(null))
                .BuildUsStreetApiClient();

            client.Send(new USStreetApi.Lookup("1 Rosedale"));

            var url = capturingSender.Request.GetUrl();
            Assert.That(url, Does.Contain("us-street.api.smarty.com"));
            Assert.That(url, Does.Contain("auth-id=test-id"));
            Assert.That(url, Does.Contain("auth-token=test-token"));
        }

        private sealed class CapturingHandler : HttpMessageHandler
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
