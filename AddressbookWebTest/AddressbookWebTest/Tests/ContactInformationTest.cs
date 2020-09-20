using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    [TestFixture]
    class ContactInformationTest : TestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactsData contactDataFromEditForm = appManager.Contacts.GetContactInformationFromEditForm(0);
           
            ContactsData contactDataFromTable  = appManager.Contacts.GetContactInformationFromTable(0);
            
            // According to the rules we have written, they are compared by first and last name
            Assert.AreEqual(contactDataFromEditForm, contactDataFromTable);
            // Add address comparison check
            Assert.AreEqual(contactDataFromEditForm.Address, contactDataFromTable.Address);
            Assert.AreEqual(contactDataFromEditForm.AllPhones, contactDataFromTable.AllPhones);
        }
    }
}
