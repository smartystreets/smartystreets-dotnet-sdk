using System;
using System.Text.RegularExpressions;

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
					throw new BadCredentialsException(
						"Unauthorized: The credentials were provided incorrectly or did not match any existing, active credentials.");
				case 402:
					throw new PaymentRequiredException(
						"Payment Required: There is no active subscription for the account associated with the credentials submitted with the request.");
				case 403:
					throw new ForbiddenException(
						"Because the international service is currently in a limited release phase, only approved accounts may access the service.");
				case 408:
					throw new RequestTimeoutException(
						"Request timeout error.");
				case 413:
					throw new RequestEntityTooLargeException(
						"Request Entity Too Large: The request body has exceeded the maximum size.");
				case 400:
					throw new BadRequestException(
						"Bad Request (Malformed Payload): A GET request lacked a street field or the request body of a POST request contained malformed JSON.");
				case 422:
					throw new UnprocessableEntityException("GET request lacked required fields.");
				case 429:
					string retry;
					Int64 retryVal = 0;

					if (response.HeaderInfo.TryGetValue("Retry-After", out retry))
					{
						Int64.TryParse(retry, out retryVal);
					}

					var errorMsg = ExtractErrorMsgFromResponse(response, "When using public \"website key\" authentication, we restrict the number of requests coming from a given source over too short of a time.");

					throw new TooManyRequestsException(errorMsg, retryVal);
				case 500:
					throw new InternalServerErrorException("Internal Server Error.");
				case 502:
					throw new BadGatewayException("Bad Gateway error.");
				case 503:
					throw new ServiceUnavailableException("Service Unavailable. Try again later.");
				case 504:
					throw new GatewayTimeoutException(
						"The upstream data provider did not respond in a timely fashion and the request failed. A serious, yet rare occurrence indeed.");
				default:
					return null;
			}
		}

		private string ExtractErrorMsgFromResponse(Response response, string defaultErrorMessage)
		{
			try
			{
				// do this in a try-catch to ensure any exception is caught.  Don't need to handle any error since we have a generic error message
				var payloadString = System.Text.Encoding.UTF8.GetString(response.Payload);
				var exp = new Regex("\"message\" *: *\"[^\"]*\""); // look for "message":"<some error text>"
				var innerExp = new Regex("\"[^\"]*\""); // look for text that is included inside of double quotes
				var matches = exp.Matches(payloadString);
				foreach (Match match in matches)
				{
					string errorPair = match.Value.Substring(9); // skip over "message"
					string error = innerExp.Match(errorPair).Value;
					if (error.Length > 2) // make sure string isn't just a quoted empty string 
					{
						return error.Substring(1, error.Length - 2);
					}
				}
			}
			catch (Exception)
			{
			}

			return defaultErrorMessage;
		}
	}
}