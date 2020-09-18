using OpenQA.Selenium;
using System;
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
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }


        private void UpdateContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
        }


        internal int GetContactsCount()
        {
            var webElementsList = driver.FindElements(By.Name("entry"));

            return webElementsList.Count;
        }


        public List<ContactsData> GetContactsList()
        {
            List<ContactsData> contactsList = new List<ContactsData>();

            appManager.Navigator.GoToHomePage();

            var webElementsList = driver.FindElements(By.Name("entry"));

            foreach (var element in webElementsList)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                contactsList.Add(new ContactsData(cells[1].Text)
                {
                    Lastname = cells[0].Text,

                    //Searching for a specific tag and its attribute in the element
                    Id = element.FindElement(By.TagName("input")).GetAttribute("id")

                    //Searching for a specific tag behind the tag in an element
                    //Id = driver.FindElement(By.TagName("input")).FindElements(By.TagName("id")).Text
                });
            }

            return contactsList;
        }
    }
}
