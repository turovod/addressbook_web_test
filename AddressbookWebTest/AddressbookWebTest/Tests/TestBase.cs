using NUnit.Framework;
using System;
using System.Text;

namespace AddressbookWebTest
{
    public class TestBase
    {
        protected AppManager appManager = AppManager.GetAppManager();

        static Random random = new Random();
        static string alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";


        protected static string GenerateRandomString(int v)
        {
            StringBuilder testElement = new StringBuilder();

            for (int i = 0; i < v; i++)
            {
                testElement.Append(Convert.ToChar(alphabet[random.Next(0, alphabet.Length)]));
                // testElement.Append(Convert.ToChar(random.Next(97, 122)));
            }

            return testElement.ToString();
        }
    }
}
