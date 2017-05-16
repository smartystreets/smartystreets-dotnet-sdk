namespace SmartyStreets
{
    public class GatewayTimeoutException : SmartyException
    {
        public GatewayTimeoutException()
        {
        }

        public GatewayTimeoutException(string message)
            : base(message)
        {
        }
    }
}