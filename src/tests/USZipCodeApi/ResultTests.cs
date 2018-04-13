namespace SmartyStreets.USZipCodeApi
{
	using System.IO;
	using System.Runtime.Serialization.Json;
	using System.Text;
	using NUnit.Framework;

	[TestFixture]
	public class ResultTests
	{
		[Test]
		public void TestIsValidReturnsTrueWhenInputIsValid()
		{
			Assert.IsTrue(new Result().IsValid());
		}

		[Test]
		public void TestIsValidReturnsFalseWhenInputIsNotValid()
		{
			const string InvalidJson = "{\"status\": \"invalid_zipcode\", \"reason\": \"invalid_reason\"}";
			var source = new MemoryStream(Encoding.ASCII.GetBytes(InvalidJson));
			var serializer = new DataContractJsonSerializer(typeof(Result));
			var result = (Result)serializer.ReadObject(source);

			Assert.IsFalse(result.IsValid());
		}
	}
}