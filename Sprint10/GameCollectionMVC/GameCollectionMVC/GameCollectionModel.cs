using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectionMVC {

    class GameCollectionModel {

        private List<GameType> aGameList;


        public GameCollectionModel() {}


        public List<GameType> GameList {
            get {
                return aGameList;
            }

        }

        private void addGameToList(GameType aGame) {

            if (null == aGameList) {
                aGameList = new List<GameType>();
                aGameList.Add(aGame);
            } else {
                aGameList.Add(aGame);
            }
        
        
        }



        public void addGameInfoToCollection(string theType, string theName, string thePlatform, string theNumberOfPlayers, string theYearCreated, string theCreatedBy, string rating, string ratingComment) {

            GameRating aRating = new GameRating();
            GameType aGame = new GameType(theType, thePlatform, theNumberOfPlayers, theName, theYearCreated, theCreatedBy);
            aRating.NumberOfStars = rating;
            aRating.Comments = ratingComment;
            aGame.Rating = aRating;

            addGameToList(aGame);

                         
        }
















    }
}
