namespace SmartyStreets.USAutocomplete
{
	using USAutocompleteApi;
	using NUnit.Framework;

	[TestFixture]
	public class ClientTests
	{
		private RequestCapturingSender capturingSender;
		private URLPrefixSender sender;

		[SetUp]
		public void Setup()
		{
			this.capturingSender = new RequestCapturingSender();
			this.sender = new URLPrefixSender("http://localhost/", this.capturingSender);
		}

		[Test]
		public void TestSendingSearchOnlyLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.sender, serializer);

			client.Send(new Lookup("1"));

			Assert.AreEqual("http://localhost/?search=1&prefer_geolocation=city", this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.sender, serializer);
			var lookup = new Lookup("1");
			lookup.MaxResults = 5;
			lookup.AddCityFilter("city");
			lookup.AddStateFilter("state");
			lookup.AddExclusion("excludedState");
			lookup.AddPreferCity("preferCity");
			lookup.AddPreferState("preferState");
			lookup.PreferRatio = 4;
			lookup.PreferGeolocation = GeolocateType.CITY;
			lookup.Selected = "selectedAddress";
			lookup.Exclude = "excludedAddress";
			lookup.Source = "all";

			client.Send(lookup);

			Assert.AreEqual(
				"http://localhost/?search=1&max_results=5&include_only_cities=city&include_only_states=state&exclude_states=excludedState&prefer_cities=preferCity&prefer_states=preferState&prefer_ratio=4&prefer_geolocation=city&selected=selectedAddress&exclude=excludedAddress&source=all",
				this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingExclude()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.sender, serializer);
			var lookup = new Lookup("1");
			lookup.Exclude = "excludedAddress";

			client.Send(lookup);

			Assert.AreEqual("http://localhost/?search=1&prefer_geolocation=city&exclude=excludedAddress", this.capturingSender.Request.GetUrl());
		}
	}
}
