using CsvHelper;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Assignment7 {
    public class FileReader : IFileReader {

        string contactsFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Contacts.csv";
        string businessFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Business.csv";
        string linkingFileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\ContactToBusiness.csv";

        public Business[] ReadBusinessFile()  {

            try {
                using var reader = new StreamReader(businessFileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<Business>().ToArray();
            }
            catch (Exception) {
                throw;
            }
        }

        public Dictionary<int, Business> ReadBusinessFileToDictionary() {
            
            try  {
                using var reader = new StreamReader(businessFileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                Dictionary<int, Business> businessDictionary = csv.GetRecords<Business>().ToDictionary(x => x.Id);
                return businessDictionary;

            }
            catch (Exception) {
                throw;
            }
        }

        public BusinessContact[] ReadContactsFile() {

            try {
                using var reader = new StreamReader(contactsFileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<BusinessContact>().ToArray();
            }
            catch (Exception){
                throw;
            }
        }

        public Dictionary<int, BusinessContact> ReadContactsFileToDictionary() {
            
            try {
                using var reader = new StreamReader(contactsFileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                Dictionary<int, BusinessContact> busContactDictionary = csv.GetRecords<BusinessContact>().ToDictionary(x => x.Id);
                return busContactDictionary;
            } catch (Exception) {
                throw;
            }
        }

        public ContactToBusiness[] ReadContactToBusinessLinkFile() {
            
            try {
                using var reader = new StreamReader(linkingFileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<ContactToBusiness>().ToArray();
            } catch (Exception){
                throw;
            }
        }

    }
}


