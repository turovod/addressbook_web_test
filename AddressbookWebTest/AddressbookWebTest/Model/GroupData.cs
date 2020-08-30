namespace AddressbookWebTest
{
    public class GroupData
    {
        string name;
        string header;
        string footer;

        public GroupData(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public string Header
        {
            get { return header; }

            set { header = value; }
        }

        public string Footer
        {
            get { return footer; }

            set { footer = value; }
        }

    }
}
