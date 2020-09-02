using OpenQA.Selenium;
using System;

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

        private void SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
        }

        private void InitGroupModification(GroupData groupData)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span["+groupData.RowModify+"]/input")).Click();
            driver.FindElement(By.XPath("(//input[@name='edit'])[2]")).Click();
        }

        public void Remove(int index)
        {
            appManager.Navigator.GoToGroupsPage();
            ExtractGroup(index);
            RemoveGroup();
            appManager.Navigator.ReturnGropsPage();
        } 

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }


        public void InitGroupCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='new'])")).Click();
        }

        public void ExtractGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

    }
}
