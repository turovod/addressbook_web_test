using NUnit.Framework;
using System.Collections.Generic;

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


            List<GroupData> oldGroupList = appManager.Groups.GetGroupsList();

            appManager.Groups.Modify(groupData);


            // ---------------------------------------------- Quick check (when tests often break)

            Assert.AreEqual(oldGroupList.Count, appManager.Groups.GetGroupsCount());

            // ---------------------------------------------- Slow check ()

            // Attention! Modification of the modified group is possible! Then the lists will be equal.

            List<GroupData> NewGroupsList = appManager.Groups.GetGroupsList();

            oldGroupList.Add(groupData);

            oldGroupList.Sort();
            NewGroupsList.Sort();

            Assert.AreNotEqual(oldGroupList, NewGroupsList);

            // -----------------------------------------------

        }
    }
}
