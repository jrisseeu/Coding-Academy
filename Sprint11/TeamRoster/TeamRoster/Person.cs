using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class Person {

        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName {get; set; }
        //Player, Parent, Coach
        public string type { get; set; }

        public Person() { }

        public Person(int aPersonId, string aFirstName, string aLastName, string aPersonType) {

            personId = aPersonId;
            firstName = aFirstName;
            lastName = aLastName;
            type = aPersonType;

        }



        public override string ToString() {
            return "Person Type: " +type + " Person ID: " +personId  + " First Name: " + firstName + " Last Name: " + lastName;

        }


    }
}
