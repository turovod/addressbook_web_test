﻿using OpenQA.Selenium;
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
                    cashGroups.Add(new GroupData(element.Text));
                }
            }

            return new List<GroupData>(cashGroups);
        }


    }
}
