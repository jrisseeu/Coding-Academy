using System;
using System.Globalization;

namespace Assignment7 {
    struct DriversLicenseStruct {

        public const string name = "Suresh Dasari";
        public string location;
        public int age;
        public DriversLicenseStruct(string loc, int theAge) {
            location = loc;
            age = theAge;
        }
    }
}
