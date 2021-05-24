using System;
using System.Collections.Generic;
using System.Text;


namespace TeamRoster {
    class TeamInfo {

        public List<Person> playerList;
        public List<Person> playerParentList;

        public int teamId {
            get; set;
        }
        public string teamName {
            get; set;
        }
        public string sportName {
            get; set;
        }
        
        public string season {
            get; set;
        }

        public TeamInfo() {
        
        }

        public TeamInfo(string aTeamName, string aSportName, string aSeason) {

            System.Random random = new System.Random();
            teamId = random.Next();
            teamName = aTeamName;
            sportName = aSportName;
            season = aSeason;

        }

        public List<Person> PlayerList {
            get {
                return playerList;
            }
        }

        public List<Person> PlayerParentList {
            get {
                return playerParentList;
            }
        }
        

        public void addPlayerToRoster(Person aPlayer) {

            if (null == playerList) {
                playerList = new List<Person>(4);
                playerList.Add(aPlayer);
            }
            else {
                playerList.Add(aPlayer);
            }
        
        }

        public void addParentOfPlayer(Person aPlayer) {

            if (null == playerParentList) {
                playerParentList = new List<Person>(4);
                playerParentList.Add(aPlayer);
            }
            else {
                playerParentList.Add(aPlayer);
            }

        }


        public override string ToString() {
            return "Team Id: " + teamId + " Team Name: " + teamName + " Sport Name: " + sportName + " Season: " + season;
        }

    }
}
