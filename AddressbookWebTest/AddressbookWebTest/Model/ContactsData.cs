using System;

namespace AddressbookWebTest
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        string firstname;
        private string allPhones;

        public ContactsData(string firstname)
        {
            this.firstname = firstname;
        }

        public bool Equals(ContactsData other)
        {
            if (this == other)
            {
                return true;
            }
            else if (this == null)
            {
                return false;
            }
            else if (firstname == other.firstname && Lastname == other.Lastname)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(ContactsData other)
        {
            if (Object.ReferenceEquals(this, null))
            {
                return 1;
            }
            if (this.Firstname != other.Firstname || this.Lastname != other.Lastname)
            {
                return -1;
            }
            return 0;
        }

        public string Firstname 
        {
            get { return firstname; }
            set { firstname = value; } 
        }

        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }

        public int RowModfy { get; set; }
        public string Id { get; set; }
        public string AllPhones 
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    // Trim removes spaces
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Fax)).Trim();
                }
            }
            set { allPhones = value; }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
