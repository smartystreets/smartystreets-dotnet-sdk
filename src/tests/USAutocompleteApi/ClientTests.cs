using System.Text;
using NUnit.Framework;

namespace SmartyStreets.USAutocompleteApi
{
    [TestFixture]
    public class ClientTests
    {
        private RequestCapturingSender capturingSender;
        private URLPrefixSender urlSender;

        [SetUp]
        public void Setup()
        {
            this.capturingSender = new RequestCapturingSender();
            this.urlSender = new URLPrefixSender("http://localhost/", this.capturingSender);
        }

        #region [ Single Lookup ]

        [Test]
        public void TestSendingSinglePrefixOnlyLookup()
        {
            var serializer = new FakeSerializer(new byte[0]);
            var client = new Client(this.urlSender, serializer);

            client.Send(new Lookup("1"));

            Assert.AreEqual("http://localhost/?prefix=1&suggestions=10&geolocate=true&geolocate_precision=city", capturingSender.Request.GetUrl());
        }

        [Test]
        public void TestSendingSingleFullyPopulatedLookup()
        {
            var serializer = new FakeSerializer(new byte[0]);
            var client = new Client(this.urlSender, serializer);
            var expectedURL = "http://localhost/?prefix=1&suggestions=2&city_filter=3&state_filter=4&prefer=5&geolocate=true&geolocate_precision=state";
            var lookup = new Lookup();
            lookup.Prefix = "1";
            lookup.MaxSuggestions = 2;
            lookup.AddCityFilter("3");
            lookup.AddStateFilter("4");
            lookup.AddPrefer("5");
            lookup.GeolocateType = GeolocateType.STATE;

            client.Send(lookup);

            Assert.AreEqual(expectedURL, capturingSender.Request.GetUrl());
        }

        #endregion

        #region [ Response Handling ]

        [Test]
        public void TestDeserializeCalledWithResponseBody()
        {
            var response = new Response(0, Encoding.ASCII.GetBytes("Hello, World!"));
            var mockSender = new MockSender(response);
            var sender = new URLPrefixSender("http://localhost/", mockSender);
            var deserializer = new FakeDeserializer(new Result());
            var client = new Client(sender, deserializer);

            client.Send(new Lookup("1"));

            Assert.AreEqual(response.Payload, deserializer.Payload);
        }

        [Test]
        public void TestRejectNullLookup()
        {
            var serializer = new FakeSerializer(null);
            var client = new Client(this.urlSender, serializer);

            Assert.Throws<SmartyException>(() => client.Send(null));
        }

        [Test]
        public void TestRejectNullPrefix()
        {
            var serializer = new FakeSerializer(null);
            var client = new Client(this.urlSender, serializer);

            Assert.Throws<SmartyException>(() => client.Send(new Lookup()));
        }

        [Test]
        public void TestRejectEmptyPrefix()
        {
            var serializer = new FakeSerializer(null);
            var client = new Client(this.urlSender, serializer);

            Assert.Throws<SmartyException>(() => client.Send(new Lookup("")));
        }


        [Test]
        public void TestResultCorrectlyAssignedToLookup()
        {
            var lookup = new Lookup("1");
            var expectedResult = new Result();

            var mockSender = new MockSender(new Response(0, Encoding.ASCII.GetBytes("{[]}")));
            var sender = new URLPrefixSender("http://localhost/", mockSender);
            var deserializer = new FakeDeserializer(expectedResult);
            var client = new Client(sender, deserializer);

            client.Send(lookup);

            Assert.AreEqual(expectedResult.Suggestions, lookup.Result);
        }

    #endregion
    }
}