using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class ContactsHelper : HelperBase
    {

        public ContactsHelper(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }
    }
}
