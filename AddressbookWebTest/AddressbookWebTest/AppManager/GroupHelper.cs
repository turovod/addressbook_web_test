using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }


        public void InitGroupCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='new'])")).Click();
        }

        public void ExtractGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

    }
}
