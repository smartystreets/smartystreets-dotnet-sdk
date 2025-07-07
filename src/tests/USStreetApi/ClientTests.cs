namespace SmartyStreets.USStreetApi
{
	using System.Collections.Generic;
	using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

	[TestFixture]
	public class ClientTests
	{
		#region [ Single Lookup ]

		[Test]
		public async Task TestSendingSingleFreeformLookup()
		{
			var sender = new RequestCapturingSender();
			var serializer = new FakeSerializer(null);
			var client = new Client(sender, serializer);

			await client.Send(new Lookup("freeform"));

			Assert.AreEqual("?street=freeform", sender.Request.GetUrl());
		}

		[Test]
		public async Task TestSendingSingleFullyPopulatedLookup()
		{
			var sender = new RequestCapturingSender();
			var serializer = new FakeSerializer(null);
			var client = new Client(sender, serializer);
			var lookup = new Lookup
			{
			    InputId = "1234",
				Addressee = "0",
				Street = "1",
				Secondary = "2",
				Street2 = "3",
				Urbanization = "4",
				City = "5",
				State = "6",
				ZipCode = "7",
				Lastline = "8",
				MatchStrategy = "enhanced"
			};

			await client.Send(lookup);

			Assert.AreEqual("?input_id=1234&street=1&street2=3&secondary=2&city=5&state=6&zipcode=7&" +
			                "lastline=8&addressee=0&urbanization=4&match=enhanced&candidates=5", sender.Request.GetUrl());
		}
		
		[Test]
		public async Task TestSendingSingleFullyPopulatedLookupWithFormatOutput()
		{
			var sender = new RequestCapturingSender();
			var serializer = new FakeSerializer(null);
			var client = new Client(sender, serializer);
			var lookup = new Lookup
			{
				InputId = "1234",
				Addressee = "0",
				Street = "1",
				Secondary = "2",
				Street2 = "3",
				Urbanization = "4",
				City = "5",
				State = "6",
				ZipCode = "7",
				Lastline = "8",
				MatchStrategy = "enhanced",
				OutputFormat = Lookup.PROJECT_USA_FORMAT
			};

			await client.Send(lookup);

			Assert.AreEqual("?input_id=1234&street=1&street2=3&secondary=2&city=5&state=6&zipcode=7&" +
			                "lastline=8&addressee=0&urbanization=4&match=enhanced&candidates=5&format=project-usa", sender.Request.GetUrl());
		}
		
		#endregion

		#region [ Batch Lookup ]

		[Test]
		public async Task TestEmptyBatchNotSent()
		{
			var sender = new RequestCapturingSender();
			var client = new Client(sender, null);

			await client.Send(new Batch());

			Assert.Null(sender.Request);
		}

		[Test]
		public async Task TestSuccessfullySendsBatchOfAddressLookups()
		{
			var sender = new RequestCapturingSender();
			var expectedPayload = Encoding.ASCII.GetBytes("Hello World!");
			var serializer = new FakeSerializer(expectedPayload);
			var client = new Client(sender, serializer);
			var batch = new Batch {new Lookup(), new Lookup()};

			await client.Send(batch);

			Assert.AreEqual(expectedPayload, sender.Request.Payload);
		}

		#endregion

		#region [ Response Handling ]

		[Test]
		public async Task TestDeserializeCalledWithResponseBody()
		{
			var response = new Response(0, Encoding.ASCII.GetBytes("Hello, world!"));
			var sender = new MockSender(response);
			var deserializer = new FakeDeserializer(null);
			var client = new Client(sender, deserializer);

			await client.Send(new Lookup());

			Assert.AreEqual(response.Payload, deserializer.Payload);
		}

		[Test]
		public async Task TestCandidatesCorrectlyAssignedToCorrespondingLookup()
		{
			var expectedCandidates = new List<Candidate> {new Candidate(0), new Candidate(1), new Candidate(1)};
			var batch = new Batch {new Lookup(), new Lookup()};

			var sender = new MockSender(new Response(0, new byte[0]));
			var deserializer = new FakeDeserializer(expectedCandidates);
			var client = new Client(sender, deserializer);

			await client.Send(batch);

			Assert.AreEqual(expectedCandidates[0], batch[0].Result[0]);
			Assert.AreEqual(expectedCandidates[1], batch[1].Result[0]);
			Assert.AreEqual(expectedCandidates[2], batch[1].Result[1]);
		}

		#endregion
	}
}