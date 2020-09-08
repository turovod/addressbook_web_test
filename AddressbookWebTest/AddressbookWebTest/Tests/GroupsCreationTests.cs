using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {

            GroupData groupData = new GroupData("ssss");
            groupData.Header = "ssss";
            groupData.Footer = "ssss";

            List<GroupData> OldGroups = appManager.Groups.GetGroupsList();

            appManager.Groups.Create(groupData);

            List<GroupData> NewGroups = appManager.Groups.GetGroupsList();

            Assert.AreEqual(OldGroups.Count + 1, NewGroups.Count);
        }
    }
}
