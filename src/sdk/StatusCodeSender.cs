using System.Threading.Tasks;

namespace SmartyStreets
{
	public class StatusCodeSender : ISender
	{
		private readonly ISender inner;

		public StatusCodeSender(ISender inner)
		{
			this.inner = inner;
		}

		public async Task<Response> SendAsync(Request request)
		{
			var response = await this.inner.SendAsync(request);

			switch (response.StatusCode)
			{
				case 200:
					return response;
				case 401:
					throw new BadCredentialsException(
						"Unauthorized: The credentials were provided incorrectly or did not match any existing, active credentials.");
				case 402:
					throw new PaymentRequiredException(
						"Payment Required: There is no active subscription for the account associated with the credentials submitted with the request.");
				case 403:
					throw new ForbiddenException(
						"Because the international service is currently in a limited release phase, only approved accounts may access the service.");
				case 413:
					throw new RequestEntityTooLargeException(
						"Request Entity Too Large: The request body has exceeded the maximum size.");
				case 400:
					throw new BadRequestException(
						"Bad Request (Malformed Payload): A GET request lacked a street field or the request body of a POST request contained malformed JSON.");
				case 422:
					throw new UnprocessableEntityException("GET request lacked required fields.");
				case 429:
					throw new TooManyRequestsException(
						"When using public \"website key\" authentication, we restrict the number of requests coming from a given source over too short of a time.");
				case 500:
					throw new InternalServerErrorException("Internal Server Error.");
				case 503:
					throw new ServiceUnavailableException("Service Unavailable. Try again later.");
				case 504:
					throw new GatewayTimeoutException(
						"The upstream data provider did not respond in a timely fashion and the request failed. A serious, yet rare occurrence indeed.");
				default:
					return null;
			}
		}
	}
}