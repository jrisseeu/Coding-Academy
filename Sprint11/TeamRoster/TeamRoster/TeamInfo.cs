using System;
using System.Collections.Generic;
using System.Text;



namespace TeamRoster {
    class TeamInfo {

        public List<Person> playerList;
        
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


        public TeamInfo(int aTeamId, string aTeamName, string aSportName, string aSeason) {

            teamId = aTeamId;
            teamName = aTeamName;
            sportName = aSportName;
            season = aSeason;

        }
        public TeamInfo(string aTeamName, string aSportName, string aSeason) {

            Random random = new Random();
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

        public void addPlayerToRoster(Person aPlayer) {

            if (null == playerList) {
                playerList = new List<Person>(4);
                playerList.Add(aPlayer);
            }
            else {
                playerList.Add(aPlayer);
            }
        
        }


        public override string ToString() {
            return "Team Id: " + teamId + " Team Name: " + teamName + " Sport Name: " + sportName + " Season: " + season;
        }

    }
}
