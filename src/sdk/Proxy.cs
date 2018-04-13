using System;
using System.Net;

namespace SmartyStreets
{
    public class Proxy
    {
        private readonly Uri address;
        private readonly string username, password;

        public Proxy() {}

        public Proxy(string address, string username, string password) : this()
        {
            this.address = new Uri(address);
            this.username = username;
            this.password = password;
        }

        public IWebProxy AsWebProxy()
        {
            if (string.IsNullOrWhiteSpace(this.username) && string.IsNullOrWhiteSpace(this.password))
                return new WebProxy{ Address = this.address };

            return new WebProxy
            {
                Address = this.address,
                Credentials = new NetworkCredential(this.username, this.password),
            };
        }
    }
}
