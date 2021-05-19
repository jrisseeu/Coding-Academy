using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollection {
    class GameRating {


        private string nrOfStars;
        private string ratingComment;


        public string NumberOfStars {
            get {
                return nrOfStars;
            }

            set {
                nrOfStars = value;
            }
        
        }


        public string Comments {
            get {
                return ratingComment;
            }

            set {
                ratingComment = value;
            }
        
        }

        public GameRating() {
            this.NumberOfStars = "";
            this.Comments = "";
        }

        public GameRating(string starRatings, string comments) {

            this.NumberOfStars = starRatings;
            this.Comments = comments;
        }


        public override string ToString() {

            return "Game ratings " + this.NumberOfStars + " Stars " + " ---Rating comments: " + this.Comments;

        }

    }
}
