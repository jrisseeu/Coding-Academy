using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    interface ITeamRoster {


        public TeamInfo createTeam(string aName, string aSport, string aSeason);

        public  void addPlayersToRoster(string aFirstName, string aLastName);

        public void addParentInfo(string aFirstName, string aLastName);

        public TeamInfo getTeamRoster();



    }
}
