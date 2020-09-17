using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsRemovalTests : TestBase
    {
       

        [Test]
        public void GroupsRemovalTest()
        {
            List<GroupData> oldGroupList = appManager.Groups.GetGroupsList();

            string id = oldGroupList[0].Id;

            appManager.Groups.Remove(1);

            // ---------------------------------------------- Quick check (when tests often break)

            Assert.AreEqual(oldGroupList.Count -1, appManager.Groups.GetGroupsCount());

            // ---------------------------------------------- Slow check

            List<GroupData> newGroupsList = appManager.Groups.GetGroupsList();

            oldGroupList.RemoveAt(0);

            Assert.AreEqual(oldGroupList, newGroupsList);

            foreach (GroupData group in newGroupsList)
            {
                Assert.AreNotEqual(group.Id, id);
            }
        }
    }
}
