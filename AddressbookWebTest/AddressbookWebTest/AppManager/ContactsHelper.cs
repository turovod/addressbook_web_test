using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            InitContactModification();
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


        private void InitContactModification()
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


        public ContactsData GetContactInformationFromTable(int index)
        {
            appManager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            return new ContactsData(cells[2].Text)
            {
                Lastname = cells[1].Text,
                Address = cells[3].Text,
                AllPhones = cells[5].Text
            };
        }

        public ContactsData GetContactInformationFromEditForm(int index)
        {
            appManager.Navigator.GoToHomePage();
            InitContactModification();


            return new ContactsData(driver.FindElement(By.Name("firstname")).GetAttribute("value"))
            {
                Middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value"),
                Lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value"),
                Nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value"),
                Title = driver.FindElement(By.Name("title")).GetAttribute("value"),
                Company = driver.FindElement(By.Name("company")).GetAttribute("value"),
                Address = driver.FindElement(By.Name("address")).GetAttribute("value"),
                Home = driver.FindElement(By.Name("home")).GetAttribute("value"),
                Mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value"),
                Work = driver.FindElement(By.Name("work")).GetAttribute("value"),
                Fax = driver.FindElement(By.Name("fax")).GetAttribute("value"),
                Email = driver.FindElement(By.Name("email")).GetAttribute("email"),
                Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value"),
                Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value")
            };  
        }

        public int GetNumberOfSerchResults()
        {
            appManager.Navigator.GoToHomePage();
            // A simple solution
            string text = driver.FindElement(By.Id("search_count")).Text;

            return Convert.ToInt32(text);

            //string text = driver.FindElement(By.TagName("label")).Text;

            //return Convert.ToInt32(new Regex(@"\d+").Match(text).Value);
        }
    }
}
