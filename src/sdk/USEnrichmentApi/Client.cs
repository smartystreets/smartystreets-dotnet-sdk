namespace SmartyStreets.USEnrichmentApi
{
    using System;

    public class Client : IUSEnrichmentClient
    {
        private readonly ISender sender;
		private readonly ISerializer serializer;

		public Client(ISender sender, ISerializer serializer)
		{
			this.sender = sender;
			this.serializer = serializer;
		}

    }
}