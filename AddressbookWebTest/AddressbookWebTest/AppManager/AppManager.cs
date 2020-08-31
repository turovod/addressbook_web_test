using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;


namespace AddressbookWebTest
{
    public class AppManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginOutHelper loginOutHelper;
        protected NavigationHelper navigationHelper;
        protected FillFormsHelper fillFormsHelper;
        protected GroupHelper groupHelper;
        protected ContactsHelper contactsHelper;


        public IWebDriver Driver { get { return driver; } }
        public string BaseURL { get { return baseURL; } }

        public LoginOutHelper Auth { get { return loginOutHelper; } }
        public NavigationHelper Navigator { get { return navigationHelper; } }
        public FillFormsHelper FillForms { get { return fillFormsHelper; } }
        public GroupHelper Groups { get { return groupHelper; } }
        public ContactsHelper Contacts { get { return contactsHelper; } }

        public AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginOutHelper = new LoginOutHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            fillFormsHelper = new FillFormsHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactsHelper = new ContactsHelper(driver);
        }

        public void Stop()
        {

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
