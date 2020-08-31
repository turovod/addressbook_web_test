using NUnit.Framework;

namespace AddressbookWebTest
{
    public class TestBase
    {
        protected AppManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new AppManager();

        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Stop();
        }
    }
}
