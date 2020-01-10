namespace SmartyStreets.USAutocompleteApi
{
	using System;
	using System.Collections;
	using System.IO;

	/// <summary>
	///     This client sends lookups to the SmartyStreets US Autocomplete API,
	///     and attaches the results to the appropriate Lookup objects.
	/// </summary>
	public class Client : IUSAutoCompleteClient
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

			if (string.IsNullOrEmpty(lookup?.Prefix))
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

			request.SetParameter("prefix", lookup.Prefix);
			request.SetParameter("suggestions", lookup.GetMaxSuggestionsStringIfSet());
			request.SetParameter("city_filter", BuildFilterString(lookup.CityFilter));
			request.SetParameter("state_filter", BuildFilterString(lookup.StateFilter));
			request.SetParameter("prefer", BuildFilterString(lookup.Prefer));
			request.SetParameter("prefer_ratio", lookup.GetPreferRatioStringIfSet());

			if (lookup.GeolocateType != GeolocateType.NONE)
			{
				request.SetParameter("geolocate", "true");
				request.SetParameter("geolocate_precision", lookup.GeolocateType);
			}
			else
			{
				request.SetParameter("geolocate", "false");
			}

			return request;
		}

		private static string BuildFilterString(ICollection list)
		{
			if (list.Count == 0)
				return null;

			var filterList = "";

			foreach (string item in list)
				filterList += item + ",";

			if (filterList.EndsWith(","))
				filterList = filterList.Substring(0, filterList.Length - 1);

			return filterList;
		}
	}
}