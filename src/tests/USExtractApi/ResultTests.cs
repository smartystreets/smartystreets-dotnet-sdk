namespace SmartyStreets.USExtractApi
{
	using System.IO;
	using System.Text;
	using NUnit.Framework;

	[TestFixture]
	public class ResultTests
	{
		private readonly NativeSerializer nativeSerializer = new NativeSerializer();

		private const string ResponsePayload = "{\"meta\":{\"lines\":1,\"unicode\":true,\"address_count\":2," +
		                                       "\"verified_count\":3,\"bytes\":4,\"character_count\":5},\"addresses\":[{\"text\":\"6\"," +
		                                       "\"verified\":true,\"line\":7,\"start\":8,\"end\":9,\"api_output\":[{}]},{\"text\":\"10\"}]}";

		[Test]
		public void TestAllFieldsFilledCorrectly()
		{
			Stream source = new MemoryStream(Encoding.ASCII.GetBytes(ResponsePayload));
			var result = this.nativeSerializer.Deserialize<Result>(source);

			var metadata = result.Metadata;
			Assert.IsNotNull(metadata);
			Assert.AreEqual(1, metadata.Lines);
			Assert.IsTrue(metadata.Unicode);
			Assert.AreEqual(2, metadata.AddressCount);
			Assert.AreEqual(3, metadata.VerifiedCount);
			Assert.AreEqual(4, metadata.Bytes);
			Assert.AreEqual(5, metadata.CharacterCount);

			var address = result.Addresses[0];

			Assert.IsNotNull(address);
			Assert.AreEqual("6", address.Text);
			Assert.IsTrue(address.Verified);
			Assert.AreEqual(7, address.Line);
			Assert.AreEqual(8, address.Start);
			Assert.AreEqual(9, address.End);
			Assert.AreEqual("10", result.Addresses[1].Text);

			var candidates = address.Candidates;
			Assert.IsNotNull(candidates);
		}
	}
}