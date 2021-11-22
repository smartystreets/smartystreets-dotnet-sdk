namespace SmartyStreets.USAutocompleteProApi
{
	using System;
	using System.Collections;
	using System.IO;

	/// <summary>
	///     This client sends lookups to the SmartyStreets US Autocomplete API,
	///     and attaches the results to the appropriate Lookup objects.
	/// </summary>
	public class Client : IUSAutoCompleteProClient
	{
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public void Send(Lookup lookup)
		{
			if (lookup == null)
				throw new ArgumentNullException("lookup");

			if (string.IsNullOrEmpty(lookup?.Search))
				throw new SmartyException("Send() must be passed a Lookup with the prefix field set.");

			var request = BuildRequest(lookup);

			var response = this.sender.Send(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var result = this.serializer.Deserialize<Result>(payloadStream) ?? new Result();
				var suggestions = result.Suggestions;
				lookup.Result = suggestions;
			}
		}

		private static Request BuildRequest(Lookup lookup)
		{
			var request = new Request();
			
			request.SetParameter("search", lookup.Search);
			request.SetParameter("max_results", lookup.GetMaxSuggestionsStringIfSet());
			request.SetParameter("include_only_cities", BuildFilterString(lookup.CityFilter));
			request.SetParameter("include_only_states", BuildFilterString(lookup.StateFilter));
			request.SetParameter("include_only_zip_codes", BuildFilterString(lookup.ZIPFilter));
			request.SetParameter("exclude_states", BuildFilterString(lookup.ExcludeStates));
			request.SetParameter("prefer_cities", BuildFilterString(lookup.PreferCities));
			request.SetParameter("prefer_states", BuildFilterString(lookup.PreferStates));
			request.SetParameter("prefer_zip_codes", BuildFilterString(lookup.PreferZIPCodes));
			request.SetParameter("prefer_ratio", lookup.GetPreferRatioStringIfSet());
			request.SetParameter("prefer_geolocation", lookup.PreferGeolocation);
			request.SetParameter("selected", lookup.Selected);
			request.SetParameter("source", lookup.Source);

			return request;
		}

		private static string BuildFilterString(ICollection list)
		{
			if (list.Count == 0)
				return null;

			var filterList = "";

			foreach (string item in list)
				filterList += item + ";";

			if (filterList.EndsWith(";"))
				filterList = filterList.Substring(0, filterList.Length - 1);

			return filterList;
		}
	}
}