using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Navigator.GoToGroupsPage();
            appManager.Groups.InitGroupCreation();

            GroupData groupData = new GroupData("ssss");
            groupData.Header = "ssss";
            groupData.Footer = "ssss";

            appManager.FillForms.FillGroupForm(groupData);
            appManager.Groups.SubmitGroupCreation();
            appManager.Navigator.ReturnGropsPage();
            appManager.Auth.Logout();
        }
    }
}
