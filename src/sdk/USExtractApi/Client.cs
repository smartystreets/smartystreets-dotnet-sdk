using System.Collections.Generic;

namespace SmartyStreets.USExtractApi
{
	using System;
	using System.IO;
	using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///     This client sends lookups to the SmartyStreets US Extract API,
    ///     and attaches the results to the Lookup objects.
    /// </summary>
    public class Client : IUSExtractClient
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

			if (string.IsNullOrEmpty(lookup?.Text))
				throw new SmartyException("Client.send() requires a Lookup with the 'text' field set");

			var request = BuildRequest(lookup);
			var response = await this.sender.SendAsync(request);

			using (var payloadStream = new MemoryStream(response.Payload))
			{
				var result = this.serializer.Deserialize<Result>(payloadStream) ?? new Result();
				lookup.Result = result;
			}
		}

		private static Request BuildRequest(Lookup lookup)
		{
			var request = new Request
			{
				ContentType = "text/plain",
				Payload = Encoding.ASCII.GetBytes(lookup.Text)
			};

			request.SetParameter("html", lookup.IsHtml());
			request.SetParameter("aggressive", lookup.IsAggressive.ToString().ToLower());
			request.SetParameter("addr_line_breaks", lookup.AddressesHaveLineBreaks.ToString().ToLower());
			request.SetParameter("addr_per_line", lookup.AddressesPerLine.ToString());
			if ((lookup.MatchStrategy != "") && (lookup.MatchStrategy != Lookup.STRICT))
				request.SetParameter("match", lookup.MatchStrategy);

			foreach (KeyValuePair<string, string> line in lookup.CustomParamDict) {
				request.SetParameter(line.Key, line.Value);
			}

			return request;
		}

		public void Dispose()
		{
			if (!this.senderWasDisposed)
			{
				sender.Dispose();
				this.senderWasDisposed = true;
			}
		}
	}
}