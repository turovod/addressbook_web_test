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

            NewGroups.Add(groupData);

            OldGroups.Sort();
            NewGroups.Sort();

            Assert.AreEqual(OldGroups, NewGroups);
        }
    }
}
