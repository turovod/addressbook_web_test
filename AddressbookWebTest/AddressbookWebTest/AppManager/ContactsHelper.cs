using OpenQA.Selenium;
using System.Collections.Generic;

namespace AddressbookWebTest
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(AppManager appManager) : base(appManager)
        {
        }

        internal void Modify(ContactsData contactsData)
        {
            appManager.Navigator.GoToHomePage();
            InitContactModification(contactsData);
            appManager.FillForms.FillContactForm(contactsData);
            UpdateContactModification();
            appManager.Navigator.GoToHomePage();
        }

        internal void Remove(int index)
        {
            appManager.Navigator.GoToHomePage();
            ExtractContact(index);
            RemoveContact();
            appManager.Navigator.GoToHomePage();
        }

        public void Create(ContactsData contactsData)
        {
            appManager.Navigator.GoToNewContacts();
            appManager.FillForms.FillContactForm(contactsData);
            SubmitContactCreation();
            appManager.Navigator.GoToHomePage();
        }

        private void ExtractContact(int index) => driver.FindElement(By.XPath("//tr[" + index + "]/td/input")).Click();
    
           

        private void RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.LinkText("home")).Click();
        }


        private void InitContactModification(ContactsData contactsData)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + contactsData.RowModfy + "]/td[8]/a/img")).Click();
        }


        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }


        private void UpdateContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
        }

        public List<ContactsData> GetContactsList()
        {
            List<ContactsData> contactsList = new List<ContactsData>();

            appManager.Navigator.GoToHomePage();

            var webElementsList = driver.FindElements(By.Name("entry"));

            foreach (var elements in webElementsList)
            {
                IList<IWebElement> cells = elements.FindElements(By.TagName("td"));

                contactsList.Add(new ContactsData(cells[1].Text) { Lastname = cells[0].Text });
            }

            return contactsList;
        }

        //public List<string> GetContactsList()
        //{
        //    List<string> contactsList = new List<string>();

        //    appManager.Navigator.GoToHomePage();

        //    var webElementsList = driver.FindElements(By.TagName("td"));

        //    foreach (var elements in webElementsList)
        //    {
        //        contactsList.Add(elements.Text);
        //    }

        //    return contactsList;
        //}

    }
}
