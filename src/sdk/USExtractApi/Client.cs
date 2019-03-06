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
    public class Client : IClient<Lookup>
	{
		private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
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

			return request;
		}
	}
}