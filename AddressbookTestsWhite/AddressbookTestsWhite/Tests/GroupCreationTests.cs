using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using NUnit.Framework;

namespace AddressbookTestsWhite
{
    [TestFixture]
    public class GroupCreationTests : TastBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroupList = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData() { Name = "White"};

            app.Groups.Add(newGroup);

            List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList.Add(newGroup);

            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList, newGroupList);
        }
    }
}
