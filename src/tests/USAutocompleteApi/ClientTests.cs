namespace SmartyStreets.USAutocompleteApi
{
	using System;
	using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

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
		public async Task TestSendingSinglePrefixOnlyLookupAsync()
		{
			var serializer = new FakeSerializer(new byte[0]);
			var client = new Client(this.urlSender, serializer);

			await client.SendAsync(new Lookup("1"));

			Assert.AreEqual("http://localhost/?prefix=1&geolocate=true&geolocate_precision=city",
				this.capturingSender.Request.GetUrl());
		}

		[Test]
		public async Task TestSendingSingleFullyPopulatedLookupAsync()
		{
			var serializer = new FakeSerializer(new byte[0]);
			var client = new Client(this.urlSender, serializer);
			const string expectedURL =
				"http://localhost/?prefix=1&suggestions=2&city_filter=3&state_filter=4&prefer=5&prefer_ratio=0.6&geolocate=true&geolocate_precision=state";
			var lookup = new Lookup
			{
				Prefix = "1",
				MaxSuggestions = 2
			};
			lookup.AddCityFilter("3");
			lookup.AddStateFilter("4");
			lookup.AddPrefer("5");
			lookup.GeolocateType = GeolocateType.STATE;
			lookup.PreferRatio = .6;

			await client.SendAsync(lookup);

			Assert.AreEqual(expectedURL, this.capturingSender.Request.GetUrl());
		}

		#endregion

		#region [ Response Handling ]

		[Test]
		public async Task TestDeserializeCalledWithResponseBodyAsync()
		{
			var response = new Response(0, Encoding.ASCII.GetBytes("Hello, World!"));
			var mockSender = new MockSender(response);
			var sender = new URLPrefixSender("http://localhost/", mockSender);
			var deserializer = new FakeDeserializer(new Result());
			var client = new Client(sender, deserializer);

			await client.SendAsync(new Lookup("1"));

			Assert.AreEqual(response.Payload, deserializer.Payload);
		}

		[Test]
		public void TestRejectNullLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.ThrowsAsync<ArgumentNullException>(async () => await client.SendAsync(null));
		}

		[Test]
		public void TestRejectNullPrefix()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.ThrowsAsync<SmartyException>(async () => await client.SendAsync(new Lookup()));
		}

		[Test]
		public void TestRejectEmptyPrefix()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.ThrowsAsync<SmartyException>(async () => await client.SendAsync(new Lookup("")));
		}


		[Test]
		public async Task TestResultCorrectlyAssignedToLookupAsync()
		{
			var lookup = new Lookup("1");
			var expectedResult = new Result();

			var mockSender = new MockSender(new Response(0, Encoding.ASCII.GetBytes("{[]}")));
			var sender = new URLPrefixSender("http://localhost/", mockSender);
			var deserializer = new FakeDeserializer(expectedResult);
			var client = new Client(sender, deserializer);

			await client.SendAsync(lookup);

			Assert.AreEqual(expectedResult.Suggestions, lookup.Result);
		}

		#endregion
	}
}