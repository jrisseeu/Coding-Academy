using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class DataAcessFactory {

        public static ITeamRosterDataAccess GetTeamRosterDao() {

            return new TeamDataAccess();
        }

    }
}
