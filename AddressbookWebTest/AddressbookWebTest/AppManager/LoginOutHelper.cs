using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class LoginOutHelper : HelperBase
    {
        public LoginOutHelper(AppManager appManager) : base(appManager)
        {
        }

        public void Login(AccountData accountData)
        {
            ClicClearSendKeys(accountData.Username, By.Name("user"));
            ClicClearSendKeys(accountData.Password, By.Name("pass"));
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
