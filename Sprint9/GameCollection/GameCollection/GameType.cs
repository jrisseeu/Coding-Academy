using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollection {
    class GameType :Game {

        private string platform;
        private string type;
        private string numberOfPlayers;
        private GameRating gameRating;


        public string Platform {

            get {
                return platform;
            }
            set {
                platform = value;
            }
        
        }


        public string NumberOfPlayers {
            get {
                return numberOfPlayers;
            }
            set {
                numberOfPlayers = value;
            }
        
        }


        public string Type {

            get {
                return type;
            }
            set {
                type = value;
            }

        }

        public GameRating rating {

            get {
                return gameRating;
            }

            set {
                gameRating = value;
            }

        }

       

        public GameType() :base() {
            platform = "";
            numberOfPlayers = "";
            type = "";
        }

        public GameType(string theType, string thePlatform, string theNumberOfPlayers, string theName, string theYearCreated, string theCreatedBy) : base(theName, theYearCreated, theCreatedBy) {
            platform = thePlatform;
            numberOfPlayers = theNumberOfPlayers;
            type = theType;
        }


        public override string ToString() {

            return this.Type + " Game " + this.Name + " was created by " + this.CreatedBy + " in " + this.YearCreated + " for playing on a " + this.Platform + " and " + this.NumberOfPlayers + " can play";

        }

    }
}
