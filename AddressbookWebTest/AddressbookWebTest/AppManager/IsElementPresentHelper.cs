using NUnit.Framework;
using OpenQA.Selenium;

namespace AddressbookWebTest 
{
    public class IsElementPresentHelper : HelperBase
    {
        public IsElementPresentHelper(AppManager appManager) : base(appManager)
        {

        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
