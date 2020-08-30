using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsRemovalTests : TestBase
    {
       

        [Test]
        public void GroupsCreationTest()
        {
            navigationHelper.OpenHomePage();
            loginOutHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.ExtractGroup(1);
            groupHelper.RemoveGroup();
            navigationHelper.ReturnGropsPage();
        }
    }
}
