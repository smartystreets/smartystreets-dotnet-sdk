namespace SmartyStreets
{
	using System;
	using System.Text;

	public class BasicAuthCredentials : ICredentials
	{
		private readonly string authId;
		private readonly string authToken;

		public BasicAuthCredentials(string authId, string authToken)
		{
			if (string.IsNullOrEmpty(authId) || string.IsNullOrEmpty(authToken))
				throw new ArgumentException("Credentials (auth id, auth token) required");

			this.authId = authId;
			this.authToken = authToken;
		}

		public void Sign(Request request)
		{
			var credentials = $"{this.authId}:{this.authToken}";
			var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
			request.SetHeader("Authorization", $"Basic {encodedCredentials}");
		}
	}
}
