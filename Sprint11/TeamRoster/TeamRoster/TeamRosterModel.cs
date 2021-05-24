using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class TeamRosterModel : ITeamRoster {

        TeamInfo theTeam {
            get; set;
        }



        public TeamInfo createTeam(string aName, string aSport, string aSeason) {

            if (theTeam == null) {
                theTeam = new TeamInfo();
            }
       
            theTeam = new TeamInfo(aName, aSport, aSeason);

            return theTeam;
        
        }


        public void addPlayersToRoster(string aFirstName, string aLastName) {


            theTeam.addPlayerToRoster(new Person(aFirstName, aLastName, "Player"));


        }

        public void addParentInfo(string aFirstName, string aLastName) {

            theTeam.addParentOfPlayer(new Person(aFirstName, aLastName, "Parent"));
        
        }

        public TeamInfo getTeamRoster() {

            return theTeam;
        
        }


    }
}
