namespace AddressbookWebTest
{
    public class AccountData
    {
        string username = "admin";
        string password = "secret";

        public AccountData (string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return username; }

            set { username = value; }
        }

        public string Password
        {
            get { return password; }

            set { password = value; }
        }
    }
}
