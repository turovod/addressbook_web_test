using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigationHelper.OpenHomePage();
            loginOutHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitGroupCreation();

            GroupData groupData = new GroupData("ssss");
            groupData.Header = "ssss";
            groupData.Footer = "ssss";

            fillFormsHelper.FillGroupForm(groupData);
            groupHelper.SubmitGroupCreation();
            navigationHelper.ReturnGropsPage();
            loginOutHelper.Logout();
        }
    }
}
