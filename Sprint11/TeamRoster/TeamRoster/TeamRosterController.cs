using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class TeamRosterController {

        TeamRosterView aView;
        TeamRosterModel aModel;

        public TeamRosterController() {

            aView = new TeamRosterView();
            aModel = new TeamRosterModel();

            aView.startTeamRoster();

            //Create the Team info
            TeamInfo aTeam = aModel.createTeam(aView.getTeamName(), aView.getTeamSport(), aView.getTeamSeason());

            //Create the player
            aModel.addPlayersToRoster(aView.getPlayerFirstNm(), aView.getPlayerLastNm());

            bool addParent = aView.addParentToStudent();
            while (addParent) {

                //Create the parent info
                aModel.addParentInfo(aView.getParentFirstNm(), aView.getParentLastNm());
                addParent = aView.addParentToStudent();

            }

            bool keepGoing = true;

            while (keepGoing) {
                string op = aView.addAnotherPlayer();

                switch (op) {
                    case "1":
                        //Create the player
                        aModel.addPlayersToRoster(aView.getPlayerFirstNm(), aView.getPlayerLastNm());
                        addParent = aView.addParentToStudent();
                        while (addParent) {
                            //Create the parent info
                            aModel.addParentInfo(aView.getParentFirstNm(), aView.getParentLastNm());
                        }
                        break;
                    case "2":

                        aView.printRosterInfo(aModel.getTeamRoster());

                        //Create the player
                        aModel.addPlayersToRoster(aView.getPlayerFirstNm(), aView.getPlayerLastNm());
                        addParent = aView.addParentToStudent();
                        while (addParent) {
                            //Create the parent info
                            aModel.addParentInfo(aView.getParentFirstNm(), aView.getParentLastNm());
                        }
                        break;
                    case "3":

                        aView.printRosterInfo(aModel.getTeamRoster());
                        keepGoing = false;
                        break;
                    case "4":
                        keepGoing = false;
                        break;


                }
            }
        }    
    }
}
