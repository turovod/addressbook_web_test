using NUnit.Framework;

namespace AddressbookWebTest
{ 
    [TestFixture]
    class ContactsRemovalTests : TestBase
    {
        [Test]
        public void ContactsRemovalTest()
        {
            appManager.Contacts.Remove(2);
        }
    }
}
