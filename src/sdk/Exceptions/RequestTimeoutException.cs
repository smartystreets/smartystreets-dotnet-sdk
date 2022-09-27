namespace SmartyStreets
{
    public class RequestTimeoutException : SmartyException
    {
        public RequestTimeoutException()
        {
        }

        public RequestTimeoutException(string message)
            : base(message)
        {
        }
    }
}