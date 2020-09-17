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

            string id = oldListContact[0].Id;

            appManager.Contacts.Remove(2);
 
             // ---------------------------------------------- Quick check (when tests often break)

            Assert.AreEqual(oldListContact.Count - 1, appManager.Contacts.GetContactsCount());

            // ---------------------------------------------- Slow check

            List<ContactsData> NewListContact = appManager.Contacts.GetContactsList();

            oldListContact.RemoveAt(0);

            Assert.AreEqual(oldListContact, NewListContact);

            foreach (ContactsData contact in NewListContact)
            {
                Assert.AreNotEqual(contact.Id, id);
            }

        }
    }
}
