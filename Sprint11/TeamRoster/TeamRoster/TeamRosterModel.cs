using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class TeamRosterModel : ITeamRoster {

        ITeamRosterDataAccess _teamDataAccess;
        LoggingService _logger;

        public TeamRosterModel(LoggingService aLog) {

            _logger = aLog;
            _teamDataAccess = DataAcessFactory.GetTeamRosterDao();
        }


        TeamInfo theTeam {
            get; set;
        }


        public TeamInfo createTeam(string aName, string aSport, string aSeason) {

            _logger.Log("Creating a new Team");

            if (theTeam == null) {
                theTeam = new TeamInfo();
            }
       
            theTeam = new TeamInfo(_teamDataAccess.generateNewTeamId(),
                                   aName,
                                   aSport,
                                   aSeason);

            _logger.Log("Created Team" +theTeam.ToString());

            return theTeam;
        
        }


        public Person createParent(string aFirstName, string aLastName) {

            _logger.Log("Creating a new Parent");
            return new Person(_teamDataAccess.generateNewPersonId(123456),
                              aFirstName,
                              aLastName,
                              "Parent");
        }

        public Player createPlayer(bool feesPaid, string aFirstName, string aLastName) {
            _logger.Log("Creating a new Player");
            return new Player(_teamDataAccess.generateNewPersonId(22456),
                               feesPaid, 
                               aFirstName, 
                               aLastName);
        
        }

        /// <summary>
        /// Inserts the newly created team to the database
        /// </summary>
        /// <param name="aTeam"></param>
        /// <returns></returns>
        public void insertTeamToDB(TeamInfo aTeam) {

            _teamDataAccess.insertTeamToDatabase(aTeam);
        }

        public TeamInfo getTeamRoster() {

            return theTeam;
        
        }


    }
}
