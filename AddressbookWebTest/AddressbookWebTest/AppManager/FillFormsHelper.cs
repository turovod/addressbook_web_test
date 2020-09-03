using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AddressbookWebTest
{
    public class FillFormsHelper : HelperBase
    {
        public FillFormsHelper(AppManager appManager) : base(appManager)
        {
        }

        public void FillGroupForm(GroupData groupData)
        {
            ClicClearSendKeys(groupData.Name, By.Name("group_name"));
            ClicClearSendKeys(groupData.Header, By.Name("group_header"));
            ClicClearSendKeys(groupData.Footer, By.Name("group_footer"));
        }

        public void FillContactForm(ContactsData contactsData)
        {
            ClicClearSendKeys(contactsData.Firstname, By.Name("firstname"));
            ClicClearSendKeys(contactsData.Middlename, By.Name("middlename"));
            ClicClearSendKeys(contactsData.Lastname, By.Name("lastname"));
            ClicClearSendKeys(contactsData.Nickname, By.Name("nickname"));
            ClicClearSendKeys(contactsData.Title, By.Name("title"));
            ClicClearSendKeys(contactsData.Company, By.Name("company"));
            ClicClearSendKeys(contactsData.Address, By.Name("address"));
            ClicClearSendKeys(contactsData.Home, By.Name("home"));
            ClicClearSendKeys(contactsData.Mobile, By.Name("mobile"));
            ClicClearSendKeys(contactsData.Work, By.Name("work"));
            ClicClearSendKeys(contactsData.Fax, By.Name("fax"));
            ClicClearSendKeys(contactsData.Email, By.Name("email"));
            ClicClearSendKeys(contactsData.Email2, By.Name("email2"));
            ClicClearSendKeys(contactsData.Email3, By.Name("email3"));
            ClicClearSendKeys(contactsData.Homepage, By.Name("homepage"));
            ClickSelectClick(By.Name("bday"), By.XPath("//option[@value='16']"), contactsData.Bday);
            ClickSelectClick(By.Name("bmonth"), By.XPath("//option[@value='September']"), contactsData.Bmonth);
            ClicClearSendKeys(contactsData.Byear, By.Name("byear"));
            ClickSelectClick(By.Name("aday"), By.XPath("//select[3]/option[17]"), contactsData.Aday);
            ClickSelectClick(By.Name("amonth"), By.XPath("//select[4]/option[12]"), contactsData.Amonth);
            ClicClearSendKeys(contactsData.Ayear, By.Name("ayear"));
            ClicClearSendKeys(contactsData.Address2, By.Name("address2"));
            ClicClearSendKeys(contactsData.Phone2, By.Name("phone2"));
            ClicClearSendKeys(contactsData.Notes, By.Name("notes"));
        }

        private void ClickSelectClick(By locatorName, By locatorXPath, string testData)
        {
            driver.FindElement(locatorName).Click();
            new SelectElement(driver.FindElement(locatorName)).SelectByText(testData);
            driver.FindElement(locatorXPath).Click();
        }

        private void ClicClearSendKeys(string testData, By locator)
        {
            driver.FindElement(locator).Click();
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(testData);
        }
    }
}
