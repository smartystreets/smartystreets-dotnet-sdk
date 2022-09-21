namespace SmartyStreets
{
    public class BadGatewayException : SmartyException
    {
        public BadGatewayException()
        {
        }

        public BadGatewayException(string message)
            : base(message)
        {
        }
    }
}