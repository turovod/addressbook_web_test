using AutoItX3Lib;

namespace AddressbookTestsAutoit
{
    public class ApplicationManager
    {
        // Since it is often needed in the code, we move it into a variable.
        public static string WINTITLE = "Free Address Book";

        private AutoItX3 aux;
        private GroupHalper groupHalper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            // SW_SHOW - show the window (else it will be in the background)
            aux.Run(@"E:\C#UnityLern\QA\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE); // pauses script execution until the specified window appears
            aux.WinActivate(WINTITLE); // Activates the specified window (gives it focus).
            aux.WinWaitActive(WINTITLE); // pauses script execution until the specified window is activated

            groupHalper = new GroupHalper(this);
        }

        public void Stop()
        {
            aux.WinWait(WINTITLE); // pauses script execution

                                         // window name, text button (not necessary), id button (ClassnameNN)
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux
        {
            get { return aux; }
        }

        public GroupHalper Groups
        {
            get { return groupHalper; }
        }
    }
}