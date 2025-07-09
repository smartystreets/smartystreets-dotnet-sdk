namespace SmartyStreets
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class LicenseSenderTests
    {
        [Test]
        public async Task TestAddingLicenses()
        {
            var licenses = new List<string>{
                "one",
                "two",
                "three"
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new LicenseSender(licenses, urlPrefixSender);

            await sender.SendAsync(new Request());

            Assert.AreEqual("license=one%2Ctwo%2Cthree", mockSender.Request.GetUrl().Split('?')[1]);
        }

        [Test]
        public async Task TestLicensesNotAdded()
        {
            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new LicenseSender(new List<string>(), urlPrefixSender);

            await sender.SendAsync(new Request());
            
            Assert.False(mockSender.Request.GetUrl().Contains("license="));
        }
    }
}