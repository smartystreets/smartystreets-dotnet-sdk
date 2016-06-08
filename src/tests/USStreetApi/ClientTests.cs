using System;
using NUnit.Framework;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SmartyStreets.USStreetApi
{
	[TestFixture]
	public class ClientTests
	{
		#region [ Single Lookup ]

		[Test]
		public void TestSendingSingleFreeformLookup()
		{
			var sender = new RequestCapturingSender();
			var serializer = new FakeSerializer(null);
			var client = new Client("http://localhost/", sender, serializer);

			client.Send(new Lookup("freeform"));

			Assert.AreEqual("http://localhost/?street=freeform", sender.Request.GetUrl());
		}

		[Test]
		public void TestSendingSingleFullyPopulatedLookup()
		{
			RequestCapturingSender sender = new RequestCapturingSender();
			FakeSerializer serializer = new FakeSerializer(null);
			Client client = new Client("http://localhost/", sender, serializer);
			Lookup lookup = new Lookup();
			lookup.Addressee = "0";
			lookup.Street = "1";
			lookup.Secondary = "2";
			lookup.Street2 = "3";
			lookup.Urbanization = "4";
			lookup.City = "5";
			lookup.State = "6";
			lookup.ZipCode = "7";
			lookup.Lastline = "8";
			lookup.MaxCandidates = 9;

			client.Send(lookup);

			Assert.AreEqual("http://localhost/?street=1&street2=3&secondary=2&city=5&state=6&zipcode=7&lastline=8&addressee=0&urbanization=4&candidates=9", sender.Request.GetUrl());
		}

		#endregion

		#region [ Batch Lookup ]

		[Test]
		public void TestEmptyBatchNotSent()
		{
			var sender = new RequestCapturingSender();
			var client = new Client("/", sender, null);

			client.Send(new Batch());

			Assert.Null(sender.Request);
		}

		[Test]
		public void TestSuccessfullySendsBatchOfAddressLookups()
		{
			var sender = new RequestCapturingSender();
			var expectedPayload = Encoding.ASCII.GetBytes("Hello World!");
			var serializer = new FakeSerializer(expectedPayload);
			var client = new Client("http://localhost/", sender, serializer);
			var batch = new Batch();
			batch.Add(new Lookup());
			batch.Add(new Lookup());

			client.Send(batch);

			Assert.AreEqual(expectedPayload, sender.Request.Payload);
		}

		#endregion

		#region [ Request Headers ]

		[Test]
		public void TestNoHeadersAddedToRequest()
		{
			this.AssertHeadersSetCorrectly(false, false);
		}

		[Test]
		public void TestIncludeInvalidHeaderCorrectlyAddedToRequest()
		{
			this.AssertHeadersSetCorrectly(true, false);
		}

		[Test]
		public void TestStandardizeOnlyHeaderCorrectlyAddedToRequest()
		{
			this.AssertHeadersSetCorrectly(false, true);
		}

		[Test]
		public void TestIncludeInvalidHeaderCorrectlyAddedToRequestWhenBothBatchOptionsAreSet()
		{
			this.AssertHeadersSetCorrectly(true, true);
		}

		private void AssertHeadersSetCorrectly(bool includeInvalid, bool standardizeOnly)
		{
			var sender = new RequestCapturingSender();
			var client = new Client("http://localhost/", sender, new FakeSerializer(new byte[0]));
			var batch = new Batch();
			batch.Add(new Lookup());

			batch.StandardizeOnly = standardizeOnly;
			batch.IncludeInvalid = includeInvalid;
			client.Send(batch);

			var request = sender.Request;
			Dictionary<string, string> headers = request.Headers;

			if (includeInvalid)
			{
				Assert.AreEqual("true", headers["X-Include-Invalid"]);
				Assert.IsFalse(headers.ContainsKey("X-Standardize-Only"));
			}
			else if (standardizeOnly)
			{
				Assert.AreEqual("true", headers["X-Standardize-Only"]);
				Assert.IsFalse(headers.ContainsKey("X-Include-Invalid"));
			}
			else
			{
				Assert.IsFalse(headers.ContainsKey("X-Standardize-Only"));
				Assert.IsFalse(headers.ContainsKey("X-Include-Invalid"));
			}
		}

		#endregion

		#region [ Response Handling ]

		[Test]
		public void testDeserializeCalledWithResponseBody()
		{
			var response = new Response(0, Encoding.ASCII.GetBytes("Hello, world!"));
			var sender = new MockSender(response);
			var deserializer = new FakeDeserializer(null);
			var client = new Client("/", sender, deserializer);

			client.Send(new Lookup());

			Assert.AreEqual(response.Payload, deserializer.Payload);
		}

		[Test]
		public void testCandidatesCorrectlyAssignedToCorrespondingLookup()
		{
			Candidate[] expectedCandidates = new Candidate[3];
			expectedCandidates[0] = new Candidate(0);
			expectedCandidates[1] = new Candidate(1);
			expectedCandidates[2] = new Candidate(1);
			var batch = new Batch();
			batch.Add(new Lookup());
			batch.Add(new Lookup());

			var sender = new MockSender(new Response(0, new Byte[0]));
			var deserializer = new FakeDeserializer(expectedCandidates);
			var client = new Client("/", sender, deserializer);

			client.Send(batch);

			Assert.AreEqual(expectedCandidates[0], batch.Get(0).Result[0]);
			Assert.AreEqual(expectedCandidates[1], batch.Get(1).Result[0]);
			Assert.AreEqual(expectedCandidates[2], batch.Get(1).Result[1]);
		}

		#endregion
	}
}