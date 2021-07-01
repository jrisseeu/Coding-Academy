using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7 {
    public interface IFileReader {


        BusinessContact[] ReadContactsFile();
        Business[] ReadBusinessFile();
        ContactToBusiness[] ReadContactToBusinessLinkFile();
        Dictionary<int, BusinessContact> ReadContactsFileToDictionary();
        Dictionary<int, Business> ReadBusinessFileToDictionary();


    }
}
