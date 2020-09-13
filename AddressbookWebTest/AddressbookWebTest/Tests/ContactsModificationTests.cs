using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    class ContactsModificationTests : TestBase
    {
        [Test]
        public void ContactsModificationTest()
        {
            ContactsData contactsData = new ContactsData("Serge");

            contactsData.Middlename = "Klementin Mod";
            contactsData.Lastname = "Unitazoff Mod";
            contactsData.Nickname = "Iorshik Mod";
            contactsData.Title = "Tra-ta-ta Mod";
            contactsData.Company = "NiPomNuv Mod";
            contactsData.Address = "Moscow, sleva Mod";
            contactsData.Home = "15 Mod";
            contactsData.Mobile = "+7 905 322 223 33";
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
            contactsData.RowModfy = 6;

            appManager.Contacts.Modify(contactsData);
        }
    }
}
