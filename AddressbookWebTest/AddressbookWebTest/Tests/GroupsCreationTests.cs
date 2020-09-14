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

            List<GroupData> oldGroupList = appManager.Groups.GetGroupsList();

            appManager.Groups.Create(groupData);


            // ---------------------------------------------- Quick check (when tests often break)

            Assert.AreEqual(oldGroupList.Count +1, appManager.Groups.GetGroupsCount());

            // ---------------------------------------------- Slow check

            List<GroupData> NewGroupsList = appManager.Groups.GetGroupsList();

            oldGroupList.Add(groupData);

            oldGroupList.Sort();
            NewGroupsList.Sort();

            Assert.AreEqual(oldGroupList, NewGroupsList);

            // -----------------------------------------------
        }
    }
}
