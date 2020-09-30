using AutoItX3Lib;

namespace AddressbookTestsAutoit
{
    public class HalperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;

        public HalperBase(ApplicationManager manager)
        {
            WINTITLE = ApplicationManager.WINTITLE;
            aux = manager.Aux;

            this.manager = manager;
        }
    }
}