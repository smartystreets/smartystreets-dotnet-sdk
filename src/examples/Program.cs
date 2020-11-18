namespace Examples
{
	internal static class Program
	{
		private static void Main()
		{
			USStreetSingleAddressExample.Run();
			USStreetLookupsWithMatchStrategyExamples.Run();
			USStreetMultipleAddressesExample.Run();
			USZipCodeSingleLookupExample.Run();
			USZipCodeMultipleLookupsExample.Run();
			InternationalStreetExample.Run();
			USExtractExample.Run();
			USAutocompleteExample.Run();
			USReverseGeoExample.Run();
		}
	}
}