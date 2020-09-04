using NUnit.Framework;
using OpenQA.Selenium;

namespace AddressbookWebTest.Tests
{
    [TestFixture]
    class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentionals()
        {
            Assert.IsTrue(appManager.IsElementPresent.IsElementPresent(By.Name("logout")));
        }
    }
}
