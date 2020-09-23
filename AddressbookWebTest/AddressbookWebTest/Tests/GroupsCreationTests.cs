using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupsCreationTests : TestBase
    {
        //public static List<GroupData> RandomGroupDataProvider()
        //{
        //    List<GroupData> groups = new List<GroupData>();

        //    for (int i = 0; i < 5; i++)
        //    {
        //        groups.Add(new GroupData(GenerateRandomString(30))
        //        {
        //            Header = GenerateRandomString(100),
        //            Footer = GenerateRandomString(100)
        //        });
        //    }

        //    return groups;
        //}

        public static List<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();

            // Если csv файл содержит первую строку, указывающую названия полей
            // Для того, что бы удалить первую строку нужно реализовать перечислимое
            IEnumerable<string> lines = File.ReadAllLines(@"TestsData\groups.csv").Skip(1);

            // Без удаления первой строки
            // string[] line = File.ReadAllLines(@"TestsData\groups.csv");

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }

        // Провайдер тестоывх данных
        [Test, TestCaseSource("GroupDataFromCsvFile")]
        public void GroupCreationTestWitsTestDataFromFile(GroupData groupData)
        {
            List<GroupData> oldGroupList = appManager.Groups.GetGroupsList();

            appManager.Groups.Create(groupData);


            // ---------------------------------------------- Quick check (when tests often break)

            Assert.AreEqual(oldGroupList.Count + 1, appManager.Groups.GetGroupsCount());

            // ---------------------------------------------- Slow check

            List<GroupData> newGroupsList = appManager.Groups.GetGroupsList();

            oldGroupList.Add(groupData);

            oldGroupList.Sort();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupList, newGroupsList);

            // -----------------------------------------------
        }

        [Test] // Test with persistent test data
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

            List<GroupData> newGroupsList = appManager.Groups.GetGroupsList();

            oldGroupList.Add(groupData);

            oldGroupList.Sort();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupList, newGroupsList);

            // -----------------------------------------------
        }
    }
}
