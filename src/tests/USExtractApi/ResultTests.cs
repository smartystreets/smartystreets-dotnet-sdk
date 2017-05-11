namespace SmartyStreets.USExtractApi
{
	using NUnit.Framework;
	using System.IO;
	using System.Text;
	using USStreetApi;

	[TestFixture]
	public class ResultTests
	{
		private NativeSerializer NativeSerializer = new NativeSerializer();
		private static string ResponsePayload = "{\"meta\":{\"lines\":1,\"unicode\":true,\"address_count\":2," +
            "\"verified_count\":3,\"bytes\":4,\"character_count\":5},\"addresses\":[{\"text\":\"6\"," +
            "\"verified\":true,\"line\":7,\"start\":8,\"end\":9,\"api_output\":[{}]},{\"text\":\"10\"}]}";

		[Test]
		public void TestAllFieldsFilledCorrectly()
		{
			Stream Source = new MemoryStream(Encoding.ASCII.GetBytes(ResponsePayload));
			Result Result = NativeSerializer.Deserialize<Result>(Source);

			Metadata Metadata = Result.Metadata;
			Assert.IsNotNull(Metadata);
			Assert.AreEqual(1, Metadata.Lines);
			Assert.IsTrue(Metadata.Unicode);
			Assert.AreEqual(2, Metadata.AddressCount);
			Assert.AreEqual(3, Metadata.VerifiedCount);
			Assert.AreEqual(4, Metadata.Bytes);
			Assert.AreEqual(5, Metadata.CharacterCount);

			Address Address = Result.Addresses[0];

			Assert.IsNotNull(Address);
			Assert.AreEqual("6", Address.Text);
			Assert.IsTrue(Address.Verified);
			Assert.AreEqual(7, Address.Line);
			Assert.AreEqual(8, Address.Start);
			Assert.AreEqual(9, Address.End);
			Assert.AreEqual("10", Result.Addresses[1].Text);

			Candidate[] Candidates = Address.Candidates;
			Assert.IsNotNull(Candidates);
		}
	}
}
