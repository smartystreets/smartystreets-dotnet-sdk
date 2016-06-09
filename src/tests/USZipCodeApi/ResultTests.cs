using System.Runtime.Serialization.Json;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace SmartyStreets.USZipCodeApi
{
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
			string invalidJson = "{\"status\": \"invalid_zipcode\", \"reason\": \"invalid_reason\"}";
			Stream source = new MemoryStream(Encoding.ASCII.GetBytes(invalidJson));
			var serializer = new DataContractJsonSerializer(typeof(Result));
			var result = (Result)serializer.ReadObject(source);

			Assert.IsFalse(result.IsValid());
		}
	}
}

