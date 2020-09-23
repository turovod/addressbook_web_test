using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    [TestFixture]

    public class FindTheNumberOfContactsTest : TestBase
    {
        [Test]

        public void FindTheNumberOfContacts()
        {
            Assert.AreEqual(appManager.Contacts.GetNumberOfSerchResults(), appManager.Contacts.GetContactsCount());
        }
    }
}
