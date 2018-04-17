namespace SmartyStreets
{
	public class Response
	{
		public int StatusCode { get; }
		public byte[] Payload { get; }

		public Response(int statusCode, byte[] payload)
		{
			this.StatusCode = statusCode;
			this.Payload = payload;
		}
	}
}