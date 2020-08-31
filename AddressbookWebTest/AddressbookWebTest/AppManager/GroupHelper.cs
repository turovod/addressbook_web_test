using OpenQA.Selenium;

namespace AddressbookWebTest
{
    public class GroupHelper : HelperBase
    {
        AppManager appManager;

        public GroupHelper(AppManager appManager) : base(appManager.Driver)
        {
            this.appManager = appManager;
        }

        public void Create(GroupData groupData)
        {
            appManager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            appManager.FillForms.FillGroupForm(groupData);
            SubmitGroupCreation();
            appManager.Navigator.ReturnGropsPage();
        }

        public void Remove()
        {
            appManager.Navigator.GoToGroupsPage();
            ExtractGroup(1);
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
