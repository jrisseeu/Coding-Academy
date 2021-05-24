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

        public Person( string aFirstName, string aLastName, string aPesonType) {

            System.Random random = new System.Random();
            personId = random.Next();

            firstName = aFirstName;
            lastName = aLastName;
            type = aPesonType;

        }



        public override string ToString() {
            return "Person Type: " +type + " Person ID: " +personId  + " First Name: " + firstName + " Last Name: " + lastName;

        }


    }
}
