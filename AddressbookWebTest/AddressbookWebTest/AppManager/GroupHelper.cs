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
        }

        private void InitGroupModification(GroupData groupData)
        {
            driver.FindElement(By.Name("edit")).Click();
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
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
        }


        public List<GroupData> GetGroupsList()
        {
            List<GroupData> groups = new List<GroupData>();

            appManager.Navigator.GoToGroupsPage();

            var elements = driver.FindElements(By.CssSelector("span.group"));

            foreach (var element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }


            return groups;
        }


    }
}
