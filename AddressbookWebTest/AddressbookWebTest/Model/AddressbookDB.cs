using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    // for using sql DB add linq2db.MySql
    public class AddressbookDB : LinqToDB.Data.DataConnection
    {
        public AddressbookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<ContactsData> Contacts { get { return GetTable<ContactsData>(); } }
    }
}
