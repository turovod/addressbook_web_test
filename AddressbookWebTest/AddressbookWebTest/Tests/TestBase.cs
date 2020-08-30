using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace AddressbookWebTest
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginOutHelper loginOutHelper;
        protected NavigationHelper navigationHelper;
        protected FillFormsHelper fillFormsHelper;
        protected GroupHelper groupHelper;
        protected ContactsHelper contactsHelper;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();

            loginOutHelper = new LoginOutHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            fillFormsHelper = new FillFormsHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactsHelper = new ContactsHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
