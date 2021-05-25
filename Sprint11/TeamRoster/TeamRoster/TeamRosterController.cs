using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class TeamRosterController {

        TeamRosterView aView;
        TeamRosterModel aModel;

        public TeamRosterController(LoggingService aLog) {

            aLog.Log("Starting Team Roster Creation");

            aView = new TeamRosterView();
            aModel = new TeamRosterModel(aLog);

            aView.startTeamRoster();

            //Create the Team info
            TeamInfo aTeam = aModel.createTeam(aView.getTeamName(), aView.getTeamSport(), aView.getTeamSeason());

            //insert the team to the database
            aModel.insertTeamToDB(aTeam);

            //Create the player
            Player aPlayer = aModel.createPlayer(true, aView.getPlayerFirstNm(), aView.getPlayerLastNm());
            List<Person> aParentList = new List<Person>(2);

            bool addParent = aView.addParentToStudent();
            while (addParent) {

                //Create the parent info
                aParentList.Add(aModel.createParent(aView.getParentFirstNm(), aView.getParentLastNm()));
                addParent = aView.addParentToStudent();

            }

            aPlayer.addParentOfPlayer(aParentList);
            aTeam.addPlayerToRoster(aPlayer);


            bool keepGoing = true;

            while (keepGoing) {
                string op = aView.addAnotherPlayer();
                aParentList = new List<Person>(2);

                switch (op) {
                    case "1":
                        //Create the player
                        aPlayer = aModel.createPlayer(true, aView.getPlayerFirstNm(), aView.getPlayerLastNm());
                        addParent = aView.addParentToStudent();
                        while (addParent) {
                            //Create the parent info
                            aParentList.Add(aModel.createParent(aView.getParentFirstNm(), aView.getParentLastNm()));
                            addParent = aView.addParentToStudent();
                        }

                        aPlayer.addParentOfPlayer(aParentList);
                        aTeam.addPlayerToRoster(aPlayer);
                        break;
                    case "2":

                        aView.printRosterInfo2(aModel.getTeamRoster());

                        //Create the player
                        aPlayer = aModel.createPlayer(true, aView.getPlayerFirstNm(), aView.getPlayerLastNm());
                        addParent = aView.addParentToStudent();

                        while (addParent) {
                            //Create the parent info
                            aParentList.Add(aModel.createParent(aView.getParentFirstNm(), aView.getParentLastNm()));
                            addParent = aView.addParentToStudent();
                        }

                        aPlayer.addParentOfPlayer(aParentList);
                        aTeam.addPlayerToRoster(aPlayer);

                        break;
                    case "3":

                        aView.printRosterInfo2(aModel.getTeamRoster());
                        keepGoing = false;
                        break;
                    case "4":
                        keepGoing = false;
                        break;


                }
            }

            aLog.Log("Ending Team Roster Creation");
        }
    }
}
