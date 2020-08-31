using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class ContactsCreationTests : TestBase
    {       
        [Test]
        public void ContactsCreationTest()
        {
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Navigator.GoToNewContacts();

            ContactsData contactsData = new ContactsData("Serge");
            contactsData.Middlename = "Klementin";
            contactsData.Lastname = "Unitazoff";
            contactsData.Nickname = "Iorshik";
            contactsData.Title = "Tra-ta-ta";
            contactsData.Company = "NiPomNu";
            contactsData.Address = "Moscow, sleva";
            contactsData.Home = "15";
            contactsData.Mobile = "+7 905 322 223 32";
            contactsData.Work = "Guard";
            contactsData.Fax = "+7 905 322 223 32";
            contactsData.Email = "superbulet@mail.ru";
            contactsData.Email2 = "superbulet@mail.ru";
            contactsData.Email3 = "superbulet@mail.ru";
            contactsData.Homepage = @"vk.com\svirepiy";
            contactsData.Bday = "15";
            contactsData.Bmonth = "May";
            contactsData.Byear = "1940";
            contactsData.Aday = "15";
            contactsData.Amonth = "May";
            contactsData.Ayear = "1940";
            contactsData.Address2 = "Moscow, sleva";
            contactsData.Phone2 = "+7 905 322 223 32";
            contactsData.Notes = "Tra-ta-ta";

            appManager.FillForms.FillContactForm(contactsData);
            appManager.Contacts.SubmitContactCreation();
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Logout();
        }
    }
}
