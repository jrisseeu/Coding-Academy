using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectionMVC {
    class GameCollectionController {

        GameCollectionView aView;
        GameCollectionModel aModel;


        public GameCollectionController() { 


            aView = new GameCollectionView();
            aModel = new GameCollectionModel();
            aView.startGameCollection();
            bool keepGoing = true;

            while (keepGoing) {

                aModel.addGameInfoToCollection(aView.getGameType(),
                                               aView.getGameName(),
                                               aView.getGameIsPlayedWhere(),
                                               aView.getGameNumberOfPlayers(),
                                               aView.getGameReleaseYear(),
                                               aView.getGameCreator(),
                                               aView.getGameRating(),
                                               aView.getGameRatingComments());

                switch (aView.continueOrEndCollection()) {
                    case "1":
                        break;
                    case "2":
                        aView.printGameCollection(aModel.GameList);
                        break;
                    case "3":
                        keepGoing = false;
                        aView.printGameCollection(aModel.GameList);
                        break;
                    case "4":
                        keepGoing = false;
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
