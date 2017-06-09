using System;
namespace SmartyStreets
{
    public class Proxy
    {
        public string Address { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Proxy(string proxyAddress, string proxyUsername, string proxyPassword)
        {
            this.Address = proxyAddress;
            this.Username = proxyUsername;
            this.Password = proxyPassword;
        }
    }
}
