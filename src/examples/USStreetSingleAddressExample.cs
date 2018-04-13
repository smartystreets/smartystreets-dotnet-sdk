namespace Examples
{
	using System;
	using System.IO;
	using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetSingleAddressExample
	{
		public static void Run()
		{
			var authId = "Your SmartyStreets Auth ID here";
			var authToken = "Your SmartyStreets Auth Token here";
			
			// We recommend storing your keys in environment variables instead---it's safer!
//			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
//			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			
			var client = new ClientBuilder(authId, authToken)
                                //.ViaProxy("http://localhost:8080", "username", "password") // uncomment this line to point to the specified proxy.
                                .BuildUsStreetApiClient();

			var lookup = new Lookup
			{
				Street = "1600 Amphitheatre Pkwy",
				City = "Mountain View",
				State = "CA"
			};

			try
			{
				client.Send(lookup);
			}
			catch (SmartyException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.StackTrace);
			}

			var candidates = lookup.Result;

			if (candidates.Count == 0)
			{
				Console.WriteLine("No candidates. This means the address is not valid.");
				return;
			}

			var firstCandidate = candidates[0];

			Console.WriteLine("Address is valid. (There is at least one candidate)\n");
			Console.WriteLine("ZIP Code: " + firstCandidate.Components.ZipCode);
			Console.WriteLine("County: " + firstCandidate.Metadata.CountyName);
			Console.WriteLine("Latitude: " + firstCandidate.Metadata.Latitude);
			Console.WriteLine("Longitude: " + firstCandidate.Metadata.Longitude);
		}
	}
}