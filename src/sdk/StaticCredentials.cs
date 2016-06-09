namespace SmartyStreets
{
	public class StaticCredentials : ICredentials
	{
		private string authId;
		private string authToken;

		public StaticCredentials(string authId, string authToken)
		{
			this.authId = authId;
			this.authToken = authToken;
		}

		public void Sign(Request request)
		{
			request.SetParameter("auth-id", this.authId);
			request.SetParameter("auth-token", this.authToken);
		}
	}
}