namespace SmartyStreets
{
	public class Response
	{
		public int StatusCode { get; private set; }
		public byte[] Payload { get; private set; }

		public Response(int statusCode, byte[] payload) {
			this.StatusCode = statusCode;
			this.Payload = payload;
		}
	}
}