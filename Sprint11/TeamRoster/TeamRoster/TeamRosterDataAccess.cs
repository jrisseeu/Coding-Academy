using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    interface ITeamRosterDataAccess : BaseDataAccessObject {


        public int generateNewTeamId();

        public TeamInfo getTeamFromDB(int teamID);

        public int generateNewPersonId(int seed);

        public void insertTeamToDatabase(TeamInfo aTeam);



    }
}
