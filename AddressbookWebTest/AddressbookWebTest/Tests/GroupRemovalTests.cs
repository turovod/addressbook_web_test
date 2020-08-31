using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsRemovalTests : TestBase
    {
       

        [Test]
        public void GroupsRemovalTest()
        {
            appManager.Groups.Remove();
        }
    }
}
