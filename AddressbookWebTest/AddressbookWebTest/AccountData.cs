﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    class AccountData
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
