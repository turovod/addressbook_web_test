using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;


namespace AddressbookWebTest
{
    public class AppManager
    {
        private IWebDriver driver;
        private string baseURL;

        private LoginOutHelper loginOutHelper;
        private NavigationHelper navigationHelper;
        private FillFormsHelper fillFormsHelper;
        private GroupHelper groupHelper;
        private ContactsHelper contactsHelper;
        private IsElementPresentHelper isElementPresentHelper;

        private static AppManager appManager;

        public IWebDriver Driver { get { return driver; } }
        public string BaseURL { get { return baseURL; } }

        public LoginOutHelper Auth { get { return loginOutHelper; } }
        public NavigationHelper Navigator { get { return navigationHelper; } }
        public FillFormsHelper FillForms { get { return fillFormsHelper; } }
        public GroupHelper Groups { get { return groupHelper; } }
        public ContactsHelper Contacts { get { return contactsHelper; } }
        public IsElementPresentHelper IsElementPresent { get { return isElementPresentHelper; } }

        private AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginOutHelper = new LoginOutHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            fillFormsHelper = new FillFormsHelper(this);
            groupHelper = new GroupHelper(this);
            contactsHelper = new ContactsHelper(this);
            isElementPresentHelper = new IsElementPresentHelper(this);
        }

        public static AppManager GetAppManager()
        {
            if (appManager == null)
            {
                appManager = new AppManager();
            }

            return appManager;
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
