using AddressbookWebTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConvertorCsvJsonXml
{
    class Program
    {

        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filenameGroup = args[1];
            // string filenameContact = args[2];
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            List<ContactsData> contacts = new List<ContactsData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });

                contacts.Add(new ContactsData(TestBase.GenerateRandomString(10))
                {
                    Middlename = TestBase.GenerateRandomString(20),
                    Lastname = TestBase.GenerateRandomString(20),
                    Nickname = TestBase.GenerateRandomString(20),
                    Company = TestBase.GenerateRandomString(20),
                    Title = TestBase.GenerateRandomString(20),
                    Address = TestBase.GenerateRandomString(20),
                    Home = TestBase.GenerateRandomString(20),
                    Mobile = TestBase.GenerateRandomString(20),
                    Work = TestBase.GenerateRandomString(20),
                    Fax = TestBase.GenerateRandomString(20),
                    Email = TestBase.GenerateRandomString(20),
                    Email2 = TestBase.GenerateRandomString(20),
                    Email3 = TestBase.GenerateRandomString(20),
                    Homepage = TestBase.GenerateRandomString(20),
                    //Bday = TestBase.GenerateRandomDay(),
                    Bmonth = TestBase.GenerateRandomString(20),
                    //Byear = TestBase.GenerateRandomYer(),
                    //Aday = TestBase.GenerateRandomDay(),
                    Amonth = TestBase.GenerateRandomString(20),
                    //Ayear = TestBase.GenerateRandomYer(),
                    Address2 = TestBase.GenerateRandomString(20),
                    Phone2 = TestBase.GenerateRandomString(20),
                    Notes = TestBase.GenerateRandomString(20),
                });
            }

            StreamWriter writerGroup = new StreamWriter(filenameGroup);
            // StreamWriter writerContact = new StreamWriter(filenameContact);

            if (format == "csv")
            {
                writeGroupsToCsvFile(groups, writerGroup);

            }
            else if (format == "xml")
            {
                writwGroupsToXmlFile(groups, writerGroup);
                // writwContactsToXmlFile(contacts, writerContact);
            }
            else if (format == "json")
            {
                writwGroupsToJsonFile(groups, writerGroup);
                // writwContactsToJsonFile(contacts, writerContact);
            }

            else
            {
                Console.WriteLine("Unrecognased format " + format);
            }
            writerGroup.Close();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine($"{group.Name}, {group.Header}, {group.Footer}");
            }
        }

        static void writwGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writwContactsToXmlFile(List<ContactsData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactsData>)).Serialize(writer, contacts);
        }

        static void writwGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {

        }

        //static void writwContactsToJsonFile(List<ContactsData> contacts, StreamWriter writer)
        //{
        //    writer.Write(JsonNet.Serialize(contacts));
        //}

    }
}
