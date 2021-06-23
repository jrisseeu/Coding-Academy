using CsvHelper;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Activities {
    class FileParserBizAndContacts
    {

        string contactsFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Contacts.csv";
        string businessFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Business.csv";
        string linkingFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\ContactToBusiness.csv";



        public void startProcess() {

            var contacts = ReadContactsFile();
            var business = ReadBusinessFile();
            var links = ReadContactToBusinessLinkFile();

            foreach (var link in links) {

                var biz = business.Where(theBiz => theBiz.Id == link.BusinessId).FirstOrDefault();

                //second option (returns a business object)
                //var biz2 = business.FirstOrDefault(b => b.Id == link.BusinessId);

                //third option (returns a business object)
                //var biz3 = business.Where(b => b.Id == link.BusinessId).Select(b => b).FirstOrDefault();

                //fourth option (returns an array)
                //var biz4 = business.Where(b => b.Id == link.BusinessId).Select(b => b).ToArray();


                var ctc = contacts.Where(theCtc => theCtc.Id == link.ContactId).FirstOrDefault();

                //Add the contact to the business
                biz.Contacts.Add(ctc);

            }

            foreach (var biz in business) {
                if (biz.Contacts.Count > 0) {
                    Console.WriteLine($"Business has at least 1 contact: {biz.Id } { biz.Name }  Count =  { biz.Contacts.Count} ");
                }

                if (biz.Contacts.Count >= 50)
                {
                    Console.WriteLine($"Business has at least 50 contacts: {biz.Id } { biz.Name }  Count =  { biz.Contacts.Count} ");
                }
            }
        }


        public void startProcess3() {

            var contacts = ReadContactsFileToDictionary();
            var business = ReadBusinessFileToDictionary();
            var links = ReadContactToBusinessLinkFile();

            foreach (var link in links){
                BusinessContact contact = contacts[link.ContactId];
                business[link.BusinessId].Contacts.Add(contact);
            }

            foreach (KeyValuePair<int, Business> biz in business) {
                if (biz.Value.Contacts.Count > 0) {
                    Console.WriteLine($"Business has at least 1 contact: {biz.Value.Id } { biz.Value.Name }  Count =  { biz.Value.Contacts.Count} ");
                }

                if (biz.Value.Contacts.Count >= 50) {
                    Console.WriteLine($"Business has at least 50 contacts: {biz.Value.Id } { biz.Value.Name }  Count =  { biz.Value.Contacts.Count} ");
                }
            }
        }

        public void startProcess4() {

            var contacts = ReadContactsFileToDictionary();
            var business = ReadBusinessFileToDictionary();
            var links = ReadContactToBusinessLinkFile();

            foreach (var link in links) {
                if (business.TryGetValue(link.BusinessId, out Business currBiz)) {
                    if (contacts.TryGetValue(link.ContactId, out BusinessContact currCtc)){
                        currBiz.Contacts.Add(currCtc);
                    }
                }
            }

            foreach (KeyValuePair<int, Business> biz in business) {
                if (biz.Value.Contacts.Count > 0) {
                    Console.WriteLine($"Business has at least 1 contact: {biz.Value.Id } { biz.Value.Name }  Count =  { biz.Value.Contacts.Count} ");
                }

                if (biz.Value.Contacts.Count >= 50) {
                    Console.WriteLine($"Business has at least 50 contacts: {biz.Value.Id } { biz.Value.Name }  Count =  { biz.Value.Contacts.Count} ");
                }
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


        private Dictionary<int, BusinessContact> ReadContactsFileToDictionary() {

            using var reader = new StreamReader(contactsFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            //Option 1 to read and create dictionary
            //var contacts = csv.GetRecords<BusinessContact>().ToArray();
            //Dictionary<int, BusinessContact> busContactDictionary = new Dictionary<int, BusinessContact>();
            //foreach (var ctc in contacts ){
            //    busContactDictionary.Add(ctc.Id, ctc);
            // }

            //Option 2
            Dictionary<int, BusinessContact> busContactDictionary = csv.GetRecords<BusinessContact>().ToDictionary(x => x.Id);

            return busContactDictionary;
        }

        private Dictionary<int, Business> ReadBusinessFileToDictionary() {

            using var reader = new StreamReader(businessFileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            //Option 1 to read and create dictionary
            //var businesses = csv.GetRecords<Business>().ToArray();
            //Dictionary<int, Business> businessDictionary = new Dictionary<int, Business>();
            //foreach (var biz in businesses) {
            //    businessDictionary.Add(biz.Id, biz);
            // }

            //Option 2
            Dictionary<int, Business> businessDictionary = csv.GetRecords<Business>().ToDictionary(x => x.Id);

            return businessDictionary;

        }
    }
}
