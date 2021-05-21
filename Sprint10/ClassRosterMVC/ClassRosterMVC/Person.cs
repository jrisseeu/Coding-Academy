using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRosterMVC {
    class Person {

        private string lastName;
        private string firstName;


        public string LastName {

            get {
                return lastName;
            }
            set {
                lastName = value;
            }

        }

        public string Firstname {
            get {
                return firstName;
            }
            set {
                firstName = value;
            }
        }

        public Person() {
        }

        public Person(string aFirstName, string aLastName) {

            firstName = aFirstName;
            lastName = aLastName;

        }

    }
}
