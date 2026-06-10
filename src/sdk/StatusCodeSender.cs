using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartyStreets
{
	public class StatusCodeSender : ISender
	{
		private bool senderWasDisposed; 
		private readonly ISender inner;

		public StatusCodeSender(ISender inner)
		{
			this.inner = inner;
		}

		public Response Send(Request request)
		{
			return SendAsync(request).GetAwaiter().GetResult();
		}

		public async Task<Response> SendAsync(Request request)
		{
			var response = await this.inner.SendAsync(request);

			switch (response.StatusCode)
			{
				case 200:
					return response;
				case 304:
					throw new NotModifiedException(
						"Not Modified: The requested record has not been modified since the previous request with the Etag value.",
						ExtractResponseEtag(response));
				case 401:
					throw new BadCredentialsException(
						ExtractErrorMsgFromResponse(response,
							"Unauthorized: The credentials were provided incorrectly or did not match any existing, active credentials."));
				case 402:
					throw new PaymentRequiredException(
						ExtractErrorMsgFromResponse(response,
							"Payment Required: There is no active subscription for the account associated with the credentials submitted with the request."));
				case 403:
					throw new ForbiddenException(
						ExtractErrorMsgFromResponse(response,
							"Forbidden: The request contained valid data and was understood by the server, but the server is refusing action."));
				case 408:
					throw new RequestTimeoutException(
						ExtractErrorMsgFromResponse(response,
							"Request timeout error."));
				case 413:
					throw new RequestEntityTooLargeException(
						ExtractErrorMsgFromResponse(response,
							"Request Entity Too Large: The request body has exceeded the maximum size."));
				case 400:
					throw new BadRequestException(
						ExtractErrorMsgFromResponse(response,
							"Bad Request (Malformed Payload): A GET request lacked a required field or the request body of a POST request contained malformed JSON."));
				case 422:
					throw new UnprocessableEntityException(
						ExtractErrorMsgFromResponse(response,
							"GET request lacked required fields."));
				case 429:
					string retry;
					Int64 retryVal = 0;

					if (response.HeaderInfo.TryGetValue("Retry-After", out retry))
					{
						Int64.TryParse(retry, out retryVal);
					}

					var errorMsg = ExtractErrorMsgFromResponse(response, "Too Many Requests: The rate limit for your account has been exceeded.");

					throw new TooManyRequestsException(errorMsg, retryVal);
				case 500:
					throw new InternalServerErrorException(
						ExtractErrorMsgFromResponse(response, "Internal Server Error."));
				case 502:
					throw new BadGatewayException(
						ExtractErrorMsgFromResponse(response, "Bad Gateway error."));
				case 503:
					throw new ServiceUnavailableException(
						ExtractErrorMsgFromResponse(response, "Service Unavailable. Try again later."));
				case 504:
					throw new GatewayTimeoutException(
						ExtractErrorMsgFromResponse(response,
							"The upstream data provider did not respond in a timely fashion and the request failed. A serious, yet rare occurrence indeed."));
				default:
					throw new SmartyException(
						ExtractErrorMsgFromResponse(response,
							"The server returned an unexpected HTTP status code: " + response.StatusCode));
			}
		}

		private static string ExtractResponseEtag(Response response)
		{
			if (response.HeaderInfo == null)
				return null;
			foreach (var entry in response.HeaderInfo)
			{
				if (string.Equals(entry.Key, "Etag", StringComparison.OrdinalIgnoreCase))
					return entry.Value;
			}
			return null;
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

		public void Dispose()
		{
			if (!senderWasDisposed)
			{
				this.inner.Dispose();
				this.senderWasDisposed = true;
			}
		}

		public void EnableLogging()
		{
			this.inner.EnableLogging();
		}
	}
}