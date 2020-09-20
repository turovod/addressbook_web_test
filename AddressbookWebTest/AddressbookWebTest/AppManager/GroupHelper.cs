using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AddressbookWebTest
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(AppManager appManager) : base(appManager)
        {
        }

        public void Create(GroupData groupData)
        {
            appManager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            appManager.FillForms.FillGroupForm(groupData);
            SubmitGroupCreation();
            appManager.Navigator.ReturnGropsPage();
        }

        internal void Modify(GroupData groupData)
        {
            appManager.Navigator.GoToGroupsPage();
            InitGroupModification(groupData);
            appManager.FillForms.FillGroupForm(groupData);
            SubmitGroupModification();
            appManager.Navigator.ReturnGropsPage();
        }

        public void Remove(int index)
        {
            appManager.Navigator.GoToGroupsPage();
            ExtractGroup(index);
            RemoveGroup();
            appManager.Navigator.ReturnGropsPage();
        }

        private void SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();

            // Clear cache
            cashGroups = null;
        }

        private void InitGroupModification(GroupData groupData)
        {
            driver.FindElement(By.Name("edit")).Click();
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();

            // Clear cache
            cashGroups = null;
        }


        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void ExtractGroup(int index)
        {
            driver.FindElement(By.Name("selected[]")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();

            // Clear cache
            cashGroups = null;
        }


        internal int GetGroupsCount()
        {
            int counts = driver.FindElements(By.CssSelector("span.group")).Count;

            return counts;
        }


        // Group data caching (Warning! Clear cache in methods Submit and Remov!)
        private List<GroupData> cashGroups = null;

        public List<GroupData> GetGroupsList()
        {
            if (cashGroups == null)
            {
                cashGroups = new List<GroupData>();

                appManager.Navigator.GoToGroupsPage();

                var elements = driver.FindElements(By.CssSelector("span.group"));

                foreach (var element in elements)
                {
                    cashGroups.Add(new GroupData(element.Text)
                    {
                        //Searching for a specific tag and its attribute in the element
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    }) ;
                }
                // ---------------------------------------------------- This code is not used

                // All group names in from div with id "content" that has a form
                string allGroupNames = driver.FindElement(By.CssSelector("div#content foprm")).Text;
                // We cut the line into words, by line break
                string[] groupName = allGroupNames.Split('\n');

                // ----------------------------------------------------
            }

            foreach (var item in cashGroups)
            {
                Console.WriteLine(item.Id);
            }

            return new List<GroupData>(cashGroups);
        }


    }
}
