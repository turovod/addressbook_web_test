using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsRemovalTests : TestBase
    {
       

        [Test]
        public void GroupsCreationTest()
        {
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Navigator.GoToGroupsPage();
            appManager.Groups.ExtractGroup(1);
            appManager.Groups.RemoveGroup();
            appManager.Navigator.ReturnGropsPage();
        }
    }
}
