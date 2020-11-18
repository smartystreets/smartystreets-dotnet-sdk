namespace SmartyStreets.USReverseGeo
{
	using System.IO;
	using System.Text;
	using USReverseGeoApi;
	using NUnit.Framework;

	[TestFixture]
	public class CandidateTest
	{
		[Test]
		public void TestAllFieldsFilledCorrectly()
		{
			const string responsePayload = "{\"results\":[" +
										   "{\"coordinate\":{\"latitude\":1.1,\"longitude\":2.2,\"accuracy\":\"3\",\"license\":4}," +
										   "\"distance\":5.5," +
										   "\"address\":{\"street\":\"6\",\"city\":\"7\",\"state_abbreviation\":\"8\",\"zipcode\":\"9\"}" +
										   "},]}";

			var nativeSerializer = new NativeSerializer();
			Result result;
			using (var payloadStream = new MemoryStream(Encoding.ASCII.GetBytes(responsePayload)))
			{
				var response = nativeSerializer.Deserialize<SmartyResponse>(payloadStream) ?? new SmartyResponse{};
				result = response.Results[0];
			}

			#region [ Result ]

			Assert.AreEqual(5.5, result.Distance);

			#endregion

			#region [ Coordinate ]

			var coordinate = result.Coordinate;
			Assert.IsNotNull(coordinate);
			Assert.AreEqual(1.1, coordinate.Latitude);
			Assert.AreEqual(2.2, coordinate.Longitude);
			Assert.AreEqual("3", coordinate.Accuracy);
			Assert.AreEqual(4, coordinate.License);

			#endregion

			#region [ Address ]

			var address = result.Address;
			Assert.IsNotNull(address);
			Assert.AreEqual("6", address.Street);
			Assert.AreEqual("7", address.City);
			Assert.AreEqual("8", address.StateAbbreviation);
			Assert.AreEqual("9", address.ZipCode);

			#endregion

		}
	}
}