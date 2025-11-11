namespace Examples
{
	using System;
	using System.IO;
	using SmartyStreets;
	using SmartyStreets.InternationalPostalCodeApi;

	internal static class InternationalPostalCodeExample
	{
		public static void Run()
		{

			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			using var client = new ClientBuilder(authId, authToken).BuildInternationalPostalCodeApiClient();

			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/cloud/international-postal-code-api

			var lookup = new Lookup
			{
				InputId = "ID-8675309", // Optional ID from your system
				Locality = "Sao Paulo",
				AdministrativeArea = "SP",
				Country = "Brazil",
				PostalCode = "02516"
			};

			//uncomment the line below to add a custom parameter
			//lookup.AddCustomParameter("postal_code", "02516");

			try
			{
				client.Send(lookup);
			}
			catch (SmartyException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				return;
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.StackTrace);
				return;
			}

			var results = lookup.Result;

			if (results == null || results.Count == 0)
			{
				Console.WriteLine("No results.");
				return;
			}

			Console.WriteLine("Results:");
			Console.WriteLine();

			for (var c = 0; c < results.Count; c++)
			{
				var candidate = results[c];
				Console.WriteLine("Candidate: " + c);
				Display(candidate.InputId);
				Display(candidate.CountryIso3);
				Display(candidate.Locality);
				Display(candidate.DependentLocality);
				Display(candidate.DoubleDependentLocality);
				Display(candidate.SubAdministrativeArea);
				Display(candidate.AdministrativeArea);
				Display(candidate.SuperAdministrativeArea);
				Display(candidate.PostalCode);
				Console.WriteLine();
			}
		}

		private static void Display(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine("  " + value);
			}
		}
	}
}

