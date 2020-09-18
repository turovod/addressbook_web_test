using OpenQA.Selenium;
using System;

namespace AddressbookWebTest
{
    public class LoginOutHelper : HelperBase
    {
        public LoginOutHelper(AppManager appManager) : base(appManager)
        {
        }

        public void Login(AccountData accountData)
        {
            if (!IsLoggedIn()) // Checking that we are not logged in
            {
                ClicClearSendKeys(accountData.Username, By.Name("user"));
                ClicClearSendKeys(accountData.Password, By.Name("pass"));
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            }
           
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        // If "logout" and "admin" is exist, we are logged in
        public bool IsLoggedIn() 
        {
            return LogoutIsPresent() && UserNameIsCorrect();
        }

        private bool LogoutIsPresent() // Checking that there is text "logout" on the page
        {
            return appManager.IsElementPresent.IsElementPresent(By.Name("logout"));
        }

        private bool UserNameIsCorrect() // Checking that UserName is "admin"
        {
            // Serching "(admin)"
            string userName = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            // Сarve "admin" of "(admin)"
            if (userName.Substring(1, userName.Length - 2) == "admin")
            {
                Console.WriteLine(userName.Substring(1, userName.Length - 2));
                return true;
            }

            return false;
        }
    }
}
