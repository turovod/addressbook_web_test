using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData groupData = new GroupData("Modify");
            groupData.Header = "Modify";
            groupData.Footer = "Modify";
            groupData.RowModify = 4;

            appManager.Groups.Modify(groupData);

        }
    }
}
