using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper (AppManager appManager, string baseURL) : base(appManager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (appManager.Driver.Url == baseURL && appManager.IsElementPresent.IsElementPresent(By.LinkText("Edit")))
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToHomePage()
        {
            if (appManager.Driver.Url == baseURL && appManager.IsElementPresent.IsElementPresent(By.LinkText("Edit")))
            {
                return;
            }

            driver.FindElement(By.LinkText("home")).Click();
        }

        public void ReturnGropsPage()
        {
            if (appManager.Driver.Url == baseURL + "group.php" && appManager.IsElementPresent.IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToGroupsPage()
        {
            if (appManager.Driver.Url == baseURL + "group.php" && appManager.IsElementPresent.IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToNewContacts()
        {
            if (appManager.IsElementPresent.IsElementPresent(By.XPath("//div[@id='content']/h1")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
