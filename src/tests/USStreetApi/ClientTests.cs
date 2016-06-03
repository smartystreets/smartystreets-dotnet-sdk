using System;
using NUnit.Framework;
using System.Text;

namespace SmartyStreets
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
		
		}

		[Test]
		public void TestIncludeInvalidHeaderCorrectlyAddedToRequest()
		{
		
		}

		[Test]
		public void TestStandardizeOnlyHeaderCorrectlyAddedToRequest()
		{
		
		}

		[Test]
		public void TestIncludeInvalidHeaderCorrectlyAddedToRequestWhenBothBatchOptionsAreSet()
		{
		
		}

		private void AssertHeadersSetCorrectly(bool includeInvalid, bool standardizeOnly)
		{
		
		}

		#endregion

		#region [ Response Handling ]

		[Test]
		public void testDeserializeCalledWithResponseBody()
		{

		}

		[Test]
		public void testCandidatesCorrectlyAssignedToCorrespondingLookup()
		{

		}

		#endregion
	}
}