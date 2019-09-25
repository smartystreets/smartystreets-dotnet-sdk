namespace SmartyStreets.USZipCodeApi
{
	using System.Text;
	using NUnit.Framework;

	[TestFixture]
	public class ClientTests
	{
		#region [ Single Lookup ]

		[Test]
		public void TestSendingSingleZipOnlyLookup()
		{
			var sender = new RequestCapturingSender();
			var serializer = new FakeSerializer(null);
			var client = new Client(sender, serializer);

			client.Send(new Lookup("1"));

			Assert.AreEqual("?zipcode=1", sender.Request.GetUrl());
		}

		[Test]
		public void TestSendingSingleFullyPopulatedLookup()
		{
			var sender = new RequestCapturingSender();
			var serializer = new FakeSerializer(null);
			var client = new Client(sender, serializer);
			var lookup = new Lookup
			{
			    InputId = "1234",
				City = "1",
				State = "2",
				ZipCode = "3"
			};

			client.Send(lookup);

			Assert.AreEqual("?input_id=1234&city=1&state=2&zipcode=3", sender.Request.GetUrl());
		}

		#endregion

		#region [ Batch Lookup ]

		[Test]
		public void TestEmptyBatchNotSent()
		{
			var sender = new RequestCapturingSender();
			var serializer = new FakeSerializer(null);
			var client = new Client(sender, serializer);

			var batch = new Batch();

			client.Send(batch);

			Assert.Null(sender.Request);
		}

		[Test]
		public void TestSuccessfullySendsBatchOfLookups()
		{
			var sender = new RequestCapturingSender();
			var expectedPayload = Encoding.ASCII.GetBytes("Hello, world!");
			var serializer = new FakeSerializer(expectedPayload);
			var client = new Client(sender, serializer);
			var batch = new Batch {new Lookup(), new Lookup()};

			client.Send(batch);

			Assert.AreEqual(expectedPayload, sender.Request.Payload);
		}

		#endregion

		#region [ Response Handling ]

		[Test]
		public void TestDeserializeCalledWithResponseBody()
		{
			var response = new Response(0, Encoding.ASCII.GetBytes("Hello, world!"));
			var sender = new MockSender(response);
			var deserializer = new FakeDeserializer(null);
			var client = new Client(sender, deserializer);

			client.Send(new Lookup());

			Assert.AreEqual(response.Payload, deserializer.Payload);
		}

		[Test]
		public void TestCandidatesCorrectlyAssignedToCorrespondingLookup()
		{
			var expectedResults = new Result[2];
			expectedResults[0] = new Result();
			expectedResults[1] = new Result();
			var batch = new Batch {new Lookup(), new Lookup()};

			var sender = new MockSender(new Response(0, new byte[0]));
			var deserializer = new FakeDeserializer(expectedResults);
			var client = new Client(sender, deserializer);

			client.Send(batch);

			Assert.AreEqual(expectedResults[0], batch[0].Result);
			Assert.AreEqual(expectedResults[1], batch[1].Result);
		}

		#endregion
	}
}