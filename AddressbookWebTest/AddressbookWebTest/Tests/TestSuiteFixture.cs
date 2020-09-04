using NUnit.Framework;

namespace AddressbookWebTest
{
    [SetUpFixture]
    class TestSuiteFixture : TestBase
    {
        [SetUp]
        public void SetupTest()
        {            
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Auth.Logout();
            appManager.Stop();
        }
    }
}
