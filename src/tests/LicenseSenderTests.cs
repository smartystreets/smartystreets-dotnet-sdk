namespace SmartyStreets
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class LicenseSenderTests
    {
        [Test]
        public void TestAddingLicenses()
        {
            var licenses = new List<string>{
                "one",
                "two",
                "three"
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new LicenseSender(licenses, urlPrefixSender);

            sender.Send(new Request());

            Assert.AreEqual("license=one%2Ctwo%2Cthree", mockSender.Request.GetUrl().Split('?')[1]);
        }

        [Test]
        public void TestLicensesNotAdded()
        {
            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new LicenseSender(new List<string>(), urlPrefixSender);

            sender.Send(new Request());
            
            Assert.False(mockSender.Request.GetUrl().Contains("license="));
        }
    }
}