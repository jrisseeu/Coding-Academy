using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRosterMVC {
    class Instructor : Person {

        private string emailAddress;




        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aFirstName"></param>
        /// <param name="aLastName"></param>
        /// <param name="emailAddress"></param>
        public Instructor(string aFirstName, string aLastName, string emailAddress) : base(aFirstName, aLastName) {

            EmailAddress = emailAddress;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {

            return "Instructor: " + this.Firstname + " " + this.LastName + " Email: " + this.EmailAddress;

        }


    }
}
