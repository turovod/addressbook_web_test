using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper (IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void ReturnGropsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToNewContacts()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
