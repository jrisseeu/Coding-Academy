using CsvHelper;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Activities {
    class FindInfoActivity5 {

        string contactsFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Contacts.csv";
        string businessFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Business.csv";
        string linkingFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\ContactToBusiness.csv";
        string bizToFind = "Edgepulse";
        string bizToFind2 = "EDgEpuLse";
        string ctctFname = "Gabie";
        string ctctLname = "Boulder";


        /// <summary>
        /// Find business that is Edgepulse matching by case
        /// </summary>
        public void startActivity() {

            var contacts = ReadContactsFile();
            var business = ReadBusinessFile();
            var links = ReadContactToBusinessLinkFile();

            foreach (var link in links) {
                var biz = business.Where(theBiz => theBiz.Id == link.BusinessId).FirstOrDefault();
                var ctc = contacts.Where(theCtc => theCtc.Id == link.ContactId).FirstOrDefault();
                biz.Contacts.Add(ctc);
            }
           
            var edgePulse = business.Where(b => b.Name == bizToFind);
            foreach (var aBiz in edgePulse) {
                Console.WriteLine($"Business : {aBiz.Id } { aBiz.Name }  Count =  { aBiz.Contacts.Count} ");
                PrintContactInfo(aBiz.Contacts);
            }
        }

        /// <summary>
        /// Find business that is Edgepulse no matter the format of the text (Upper or lower)
        /// </summary>
        public void startActivityPart2() {
            
            var contacts = ReadContactsFile();
            var business = ReadBusinessFile();
            var links = ReadContactToBusinessLinkFile();

            foreach (var link in links) {
                var biz = business.Where(theBiz => theBiz.Id == link.BusinessId).FirstOrDefault();
                var ctc = contacts.Where(theCtc => theCtc.Id == link.ContactId).FirstOrDefault();
                biz.Contacts.Add(ctc);
            }

            var edgePulse = business.Where(b => b.Name.ToLower().Contains(bizToFind2.ToLower()));
            foreach (var aBiz in edgePulse) {
                Console.WriteLine($"Business : { aBiz.Id } { aBiz.Name }  Count =  { aBiz.Contacts.Count} ");
                PrintContactInfo(aBiz.Contacts);
            }
        }

        /// <summary>
        /// Get businesses that have contact  --> Gabie Boulder
        /// </summary>
        public void startActivityPart3() {

            var contacts = ReadContactsFile();
            var business = ReadBusinessFile();
            var links = ReadContactToBusinessLinkFile();

            foreach (var link in links) {
                var biz = business.Where(theBiz => theBiz.Id == link.BusinessId).FirstOrDefault();
                var ctc = contacts.Where(theCtc => theCtc.Id == link.ContactId).FirstOrDefault();
                biz.Contacts.Add(ctc);
            }

            foreach (var aBiz in business) {
                bool foundCtc = aBiz.Contacts.Any(aCtc => (aCtc.FirstName.ToLower().Contains(ctctFname.ToLower()))
                                              && (aCtc.LastName.ToLower().Contains(ctctLname.ToLower())));
                if (foundCtc) {
                    Console.WriteLine("This business has Gabi as a contact " + aBiz.ToString());
                }
            }
        }

        /// <summary>
        /// Get the most used contact by all businesses (link file)
        /// </summary>
        public void startActivityPart4() {

            var contacts = ReadContactsFile();
            var links = ReadContactToBusinessLinkFile();

            var mostUsed = links.GroupBy(ctcGroup => ctcGroup).OrderBy(ctcOrderBy => ctcOrderBy.Count()).Last().Key;
            var mostCtc = contacts.Where(theCtc => theCtc.Id == mostUsed.ContactId).FirstOrDefault();
            Console.WriteLine($" Contact id: {mostCtc.Id } has the most businesses associated to it:  {mostCtc.FirstName} {mostCtc.LastName}" );

            var least = links.GroupBy(ctcGroup => ctcGroup).OrderBy(ctcOrderBy => ctcOrderBy.Count()).First().Key;
            var leastCtc = contacts.Where(theCtc => theCtc.Id == least.ContactId).FirstOrDefault();
            Console.WriteLine($" Contact id: {leastCtc.Id } was used more than once & was used the least:  {leastCtc.FirstName} {leastCtc.LastName}");
        }


        /// <summary>
        /// print the contact info
        /// </summary>
        /// <param name="contact"></param>
        public void PrintContactInfo(List<BusinessContact> contact) {

            foreach (var c in contact) {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }


        private BusinessContact[] ReadContactsFile() {

            using var reader = new StreamReader(contactsFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<BusinessContact>().ToArray();
        }

        private Business[] ReadBusinessFile() {

            using var reader = new StreamReader(businessFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Business>().ToArray();
        }

        private ContactToBusiness[] ReadContactToBusinessLinkFile() {

            using var reader = new StreamReader(linkingFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<ContactToBusiness>().ToArray();
        }
       
    }
}
