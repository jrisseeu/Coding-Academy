using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRoster {
    class Instructor :Person {

        private string emailAddress;


        public string EmailAddress {

            get {
                return emailAddress;
            }

            set {
                emailAddress = value;
            }
        }

        public Instructor() : base() {

            emailAddress = "";
        }

        public Instructor(string aFirstName, string aLastName, string emailAddress) :base(aFirstName, aLastName) {

            EmailAddress = emailAddress;
        }


        public override string ToString() {

            return "Instructor: " + this.Firstname + " " + this.LastName + " " + this.EmailAddress;

        }


    }
}
