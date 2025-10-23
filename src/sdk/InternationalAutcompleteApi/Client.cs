﻿namespace SmartyStreets.InternationalAutocompleteApi
{
	using System;
	using System.IO;
	using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    ///     This client sends lookups to the SmartyStreets US Autocomplete API,
    ///     and attaches the results to the appropriate Lookup objects.
    /// </summary>
    public class Client : IInternationalAutoCompleteClient
    {
	    private bool senderWasDisposed; 
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

		public void Send(Lookup lookup)
		{
			SendAsync(lookup).GetAwaiter().GetResult();
		}

		public async Task SendAsync(Lookup lookup)
		{
			if (lookup == null)
				throw new ArgumentNullException("lookup");

			if (string.IsNullOrEmpty(lookup?.Country))
				throw new SmartyException("Send() must be passed a Lookup with the country field set.");

			if (string.IsNullOrEmpty(lookup?.Search) && string.IsNullOrEmpty(lookup?.AddressID))
				throw new SmartyException("Send() must be passed a Lookup with the search or addressID field set.");


			var request = BuildRequest(lookup);

			var response = await this.sender.SendAsync(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var result = this.serializer.Deserialize<Result>(payloadStream) ?? new Result();
				var candidates = result.Candidates;
				lookup.Result = candidates;
			}

		}

		private static Request BuildRequest(Lookup lookup)
		{
			var request = new Request();

			if (lookup.AddressID != null) {
				request.SetUrlComponents("/" + lookup.AddressID);
			}
			
			request.SetParameter("search", lookup.Search);
			request.SetParameter("country", lookup.Country);
			request.SetParameter("max_results", lookup.MaxSuggestionsString);
			request.SetParameter("include_only_locality", lookup.Locality);
			request.SetParameter("include_only_postal_code", lookup.PostalCode);

			foreach (KeyValuePair<string, string> line in lookup.CustomParamDict) {
				request.SetParameter(line.Key, line.Value);
			}
			
			return request;
		}

		public void Dispose()
		{
			if (!this.senderWasDisposed)
			{
				this.sender.Dispose();
				this.senderWasDisposed = true;
			}
		}
	}
}