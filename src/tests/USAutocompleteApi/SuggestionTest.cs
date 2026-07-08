namespace SmartyStreets.USAutocomplete
{
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using USAutocompleteApi;
	using NUnit.Framework;

	[TestFixture]
	public class SuggestionTests
	{
		[Test]
		public void TestUrbanizationDeserialization()
		{
			var nativeSerializer = new NativeSerializer();
			var rawJSON = @"{""suggestions"":[
				{""smarty_key"":""1"",""entry_id"":""2"",""urbanization"":""urb"",""street_line"":""3"",""secondary"":""4"",""city"":""5"",""state"":""6"",""zipcode"":""7"",""entries"":8,""source"":""9""},
				{""smarty_key"":""10"",""entry_id"":""11"",""street_line"":""12"",""secondary"":""13"",""city"":""14"",""state"":""15"",""zipcode"":""16"",""entries"":17,""source"":""18""}
			]}";

			var bytes = Encoding.ASCII.GetBytes(rawJSON);
			var stream = new MemoryStream(bytes);

			var actual = nativeSerializer.Deserialize<Result>(stream);

			Assert.AreEqual("urb", actual.Suggestions[0].Urbanization);
			Assert.AreEqual(null, actual.Suggestions[1].Urbanization);
		}
	}
}
