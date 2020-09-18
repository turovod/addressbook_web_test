using NUnit.Framework;
using OpenQA.Selenium;

namespace AddressbookWebTest
{
    [TestFixture]
    class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentionals()
        {
            // Assert.IsTrue(appManager.IsElementPresent.IsElementPresent(By.Name("logout")));

            Assert.IsTrue(appManager.Auth.IsLoggedIn());
        }
    }
}
