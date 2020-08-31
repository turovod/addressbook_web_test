using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class ContactsHelper : HelperBase
    {
        AppManager appManager;

        public ContactsHelper(AppManager appManager) : base(appManager.Driver)
        {
            this.appManager = appManager;
        }

        public void Create(ContactsData contactsData)
        {
            appManager.Navigator.GoToNewContacts();
            appManager.FillForms.FillContactForm(contactsData);
            SubmitContactCreation();
            appManager.Navigator.GoToHomePage();
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }
    }
}
