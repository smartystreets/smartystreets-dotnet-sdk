namespace SmartyStreets
{
	public class StatusCodeSender : ISender
	{
		private readonly ISender inner;

		public StatusCodeSender(ISender inner)
		{
			this.inner = inner;
		}

		public Response Send(Request request)
		{
			var response = this.inner.Send(request);

			switch (response.StatusCode) 
			{
				case 200:
					return response;
				case 401:
					throw new BadCredentialsException("Unauthorized: The credentials were provided incorrectly or did not match any existing, active credentials.");
				case 402:
					throw new PaymentRequiredException("Payment Required: There is no active subscription for the account associated with the credentials submitted with the request.");
				case 413:
					throw new RequestEntityTooLargeException("Request Entity Too Large: The request body has exceeded the maximum size.");
				case 400:
					throw new BadRequestException("Bad Request (Malformed Payload): A GET request lacked a street field or the request body of a POST request contained malformed JSON.");
				case 429:
					throw new TooManyRequestsException("When using public \"website key\" authentication, we restrict the number of requests coming from a given source over too short of a time.");
				case 500:
					throw new InternalServerErrorException("Internal Server Error.");
				case 503:
					throw new ServiceUnavailableException("Service Unavailable. Try again later.");
				default:
					return null;
			}
		}
	}
}
