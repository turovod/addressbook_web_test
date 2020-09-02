using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected AppManager appManager;

        public HelperBase(AppManager appManager)
        {
            this.driver = appManager.Driver;
            this.appManager = appManager;
        }
    }
}
