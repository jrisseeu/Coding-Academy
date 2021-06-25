using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment7
{
    public class BusinessLogic : IBusinessLogic, IBusinessLogicDictionary {

      
        public void FindBusinessWithContacts() {

            IFileReader fileReader = new FileReader();
            var businesses = fileReader.ReadBusinessFile();
            var contacts = fileReader.ReadContactsFile();
            var links = fileReader.ReadContactToBusinessLinkFile();

            foreach (var link in links) {

                var biz = businesses.Where(theBiz => theBiz.Id == link.BusinessId).FirstOrDefault();
                var ctc = contacts.Where(theCtc => theCtc.Id == link.ContactId).FirstOrDefault();

                //Add the contact to the business
                biz.Contacts.Add(ctc);
            }

            foreach (var biz in businesses) {

                if (biz.Contacts.Count > 0) {
                    Console.WriteLine($"Business has at least 1 contact: {biz.Id } { biz.Name }  Count =  { biz.Contacts.Count} ");
                }

                if (biz.Contacts.Count >= 50){
                    Console.WriteLine($"Business has at least 50 contacts: {biz.Id } { biz.Name }  Count =  { biz.Contacts.Count} ");
                }
            }
        }

        public void FindBusinessWithContactsUsingDictionary() {

            IFileReader fileReader = new FileReader();
            var businesses = fileReader.ReadBusinessFileToDictionary();
            var contacts = fileReader.ReadContactsFileToDictionary();
            var links = fileReader.ReadContactToBusinessLinkFile();

            foreach (var link in links)
            {
                BusinessContact contact = contacts[link.ContactId];
                businesses[link.BusinessId].Contacts.Add(contact);
            }

            foreach (KeyValuePair<int, Business> biz in businesses)
            {
                if (biz.Value.Contacts.Count > 0)
                {
                    Console.WriteLine($"Business has at least 1 contact: {biz.Value.Id } { biz.Value.Name }  Count =  { biz.Value.Contacts.Count} ");
                }

                if (biz.Value.Contacts.Count >= 50)
                {
                    Console.WriteLine($"Business has at least 50 contacts: {biz.Value.Id } { biz.Value.Name }  Count =  { biz.Value.Contacts.Count} ");
                }
            }


        }


    }
}
