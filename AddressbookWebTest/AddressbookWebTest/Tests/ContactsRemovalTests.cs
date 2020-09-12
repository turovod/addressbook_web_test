using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest
{ 
    [TestFixture]
    class ContactsRemovalTests : TestBase
    {
        [Test]
        public void ContactsRemovalTest()
        {
            List<ContactsData> oldListContact = appManager.Contacts.GetContactsList();

            appManager.Contacts.Remove(2);

            List<ContactsData> NewListContact = appManager.Contacts.GetContactsList();

            oldListContact.RemoveAt(0);

            Assert.AreEqual(oldListContact, NewListContact);

        }
    }
}
