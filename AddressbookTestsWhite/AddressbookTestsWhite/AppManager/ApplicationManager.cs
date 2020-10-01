using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace AddressbookTestsWhite
{
    public class ApplicationManager
    {
        // Since it is often needed in the code, we move it into a variable.
        public static string WINTITLE = "Free Address Book";

        private GroupHalper groupHalper;

        // Run addressbook
        public ApplicationManager()
        {
            Application app = Application.Launch((@"E:\C#UnityLern\QA\FreeAddressBookPortable\AddressBook.exe"));
            
            // Remember window "Free Address Book"
            MainWindow = app.GetWindow(WINTITLE);

            groupHalper = new GroupHalper(this);
        }

        public void Stop()
        {
            // To get the id of the button you need "Visual UI Automation Verify" programm
                                    // Automation Id
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public GroupHalper Groups
        {
            get { return groupHalper; }
        }

        public Window MainWindow { get; private set; }
    }
}