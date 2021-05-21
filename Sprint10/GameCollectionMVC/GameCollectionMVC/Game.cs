using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectionMVC {
    class Game {

        private string name;
        private string yearCreated;
        private string createdBy;
        

        public string Name {

            get {
                return name;
            }
            set {
                name = value;
            }
        }
        public string YearCreated {

            get {
                return yearCreated;
            }
            set {
                yearCreated = value;
            }
        }

        public string CreatedBy {

            get {
                return createdBy;
            }
            set {
                createdBy = value;
            }
        }

        public Game() {
            name = "";
            yearCreated = "";
            createdBy = "";
        }

        public Game(string theName, string theYearCreated, string theCreatedBy) {

            name = theName;
            yearCreated = theYearCreated;
            createdBy = theCreatedBy;
        }

    }
}
