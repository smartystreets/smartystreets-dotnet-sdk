using System;
using SmartyStreets;
using SmartyStreets.USAutocompleteApi;

namespace Examples
{
    internal static class USAutocompleteExample
    {
        public static void Run()
        {
            // We recommend storing your secret keys in environment variables.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
            var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
            var client = new ClientBuilder(authId, authToken).BuildUsAutocompleteApiClient();
            var lookup = new Lookup("4770 Lincoln Ave O");

            client.Send(lookup);

            Console.WriteLine("*** Result with no filter ***");
            Console.WriteLine();
            foreach (var suggestion in lookup.Result)
            {
                Console.WriteLine(suggestion.Text);
            }

            lookup.AddStateFilter("IL");
            lookup.MaxSuggestions = 5;

            client.Send(lookup);

            var suggestions = lookup.Result;

            Console.WriteLine();
            Console.WriteLine("*** Result with some filters ***");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine(suggestion.Text);
            }
        }
    }
}