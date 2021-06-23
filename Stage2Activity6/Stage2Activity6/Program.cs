using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Stage2Activity6
{
    static class Program {

        static readonly string contactsFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Contacts.csv";
        static readonly string businessFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Business.csv";
        static readonly string linkingFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\ContactToBusiness.csv";
        static readonly string bizToFind = "Edgepulse";
        static readonly string ctctFname = "Gabie";
        static readonly string ctctLname = "Boulder";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {


            StartActivity();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void StartActivity()
        {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };


            var contacts = ReadContactsFile();
            var businesses = ReadBusinessFile();
            var links = ReadContactToBusinessLinkFile();

            foreach (var link in links)
            {
                var biz = businesses.Where(theBiz => theBiz.Id == link.BusinessId).FirstOrDefault();
                var ctc = contacts.Where(theCtc => theCtc.Id == link.ContactId).FirstOrDefault();
                biz.Contacts.Add(ctc);
            }

            // how many businesses have contacts
            Console.WriteLine("Businesses with contacts = " + businesses.Where(b => b.Contacts.Count() > 0).Count());

            // how many businesses have more than contacts
            Console.WriteLine("Businesses with more than 50 contacts = " + businesses.Where(b => b.Contacts.Count() > 50).Count());

            var edgePulse = businesses.Where(b => b.Name.ToLower().Contains(bizToFind.ToLower()));
            foreach (var aBiz in edgePulse)
            {
                Console.WriteLine($"Business : {aBiz.Id } { aBiz.Name }  Count =  { aBiz.Contacts.Count} ");
                PrintContactInfo(aBiz.Contacts);
            }

            //***********************************************************
            // Step 3 - Business Extension
            //***********************************************************
            // Find all businesses that have Gabie Boulder as a contact
            var gabBusinesses = Search(businesses, ctctFname, ctctLname);
            foreach (var aBiz in gabBusinesses)
            {
                //bool foundCtc = aBiz.Contacts.Any(aCtc => (aCtc.FirstName.ToLower().Contains(ctctFname.ToLower()))
                //                              && (aCtc.LastName.ToLower().Contains(ctctLname.ToLower())));
                //if (foundCtc)
                // {
                Console.WriteLine("This business has Gabi as a contact " + aBiz.ToString());
                // }
            }


            //***********************************************************
            // Step 2 - Contact Extension
            //***********************************************************
            BusinessContact maxContact = null;
            int maxContactBusinessCount = 0;
            foreach (var contact in contacts)
            {
                //var count = BusinessesAssociatedWithContact(contact.Id, businesses);
                var count = Businesses(contact, businesses).Length;

                if (maxContact == null || count > maxContactBusinessCount) {
                    maxContact = contact;
                    maxContactBusinessCount = count;
                }
            }

            Console.WriteLine($"Contact {maxContact.FirstName} {maxContact.LastName} as the most businesses associated with { maxContactBusinessCount } ");



            BusinessContact nullCtc = null;
            Console.WriteLine(nullCtc.NullSomething());

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static string NullSomething(this BusinessContact contact) { 
            return contact.LastName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="businesses"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static Business[] Search(this Business[] businesses, string firstName, string lastName) {

            return businesses.Where(b => b.Contacts.Any(c => c.FirstName.ToLower() == firstName.ToLower()
                                && c.LastName.ToLower() == lastName.ToLower())).ToArray();
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="businesses"></param>
        /// <returns></returns>
        public static Business[] Businesses(this BusinessContact contact, Business[] businesses) {
            return businesses.Where(b => b.Contacts.Any(c => c.Id == contact.Id)).ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="businesses"></param>
        /// <returns></returns>
        private static int BusinessesAssociatedWithContact(int contactId, Business[] businesses)
        {
            return businesses.Where(b => b.Contacts.Any(c => c.Id == contactId)).Count();
        }


        /// <summary>
        /// print the contact info
        /// </summary>
        /// <param name="contact"></param>
        public static void PrintContactInfo(List<BusinessContact> contact)
        {

            foreach (var c in contact)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }
        private static BusinessContact[] ReadContactsFile()
        {

            using var reader = new StreamReader(contactsFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<BusinessContact>().ToArray();
        }

        private static Business[] ReadBusinessFile()
        {

            using var reader = new StreamReader(businessFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Business>().ToArray();
        }

        private static ContactToBusiness[] ReadContactToBusinessLinkFile()
        {

            using var reader = new StreamReader(linkingFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<ContactToBusiness>().ToArray();
        }
    }
}
