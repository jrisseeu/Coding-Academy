using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class TeamDataAccess : ITeamRosterDataAccess {


        public TeamDataAccess() { }


        public int generateNewPersonId(int seed) {

            return new Random(seed).Next();
            
        }

        public int generateNewTeamId() {

            return new Random().Next();
        }

        public TeamInfo getTeamFromDB(int teamID) {

            return new TeamInfo();
            
        }

        public void insertTeamToDatabase(TeamInfo aTeam) {

        }



    }
}
