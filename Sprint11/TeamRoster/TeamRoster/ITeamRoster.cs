using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    interface ITeamRoster {


       
        public TeamInfo createTeam(string aName, string aSport, string aSeason);

        public Player createPlayer(bool feesPaid, string aFirstName, string aLastName);

        public Person createParent(string aFirstName, string aLastName);

        public void insertTeamToDB(TeamInfo aTeam);

        public TeamInfo getTeamRoster();



    }
}
