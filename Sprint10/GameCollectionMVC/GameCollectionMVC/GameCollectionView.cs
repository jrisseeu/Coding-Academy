using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectionMVC {
    class GameCollectionView {

        private string[] OperationType = { "1", "2", "3" };
        private string[] ContinueOrEndTypes = { "1", "2", "3" };
        private string[] GameLocation = { "1", "2", "3", "4", "5", "6" };
        public GameCollectionView() {
        }


        public void startGameCollection() {

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Welcome to your game collection maintenance application  ");
            Console.WriteLine("---------------------------------------------------------");
        }

        public string continueOrEndCollection() {

            Console.Clear();
            Console.WriteLine("Enter 1 to add more games ");
            Console.WriteLine("Enter 2 to print and add more to the game collection ");
            Console.WriteLine("Enter 3 to print the collection and quit ");
            Console.WriteLine("Enter 4 to quit ");
            Console.WriteLine();

            string opValue = Console.ReadLine();

            while (!validateContinueOrEndTypes(opValue)) {
                Console.Write("This is not a valid selection. Please enter a valid option: ");
                opValue = Console.ReadLine();
            }

            return opValue;
        }


        public string getGameType() {

            Console.WriteLine();
            Console.WriteLine("Enter 1 to add a board Game ");
            Console.WriteLine("Enter 2 to add a card game ");
            Console.WriteLine("Enter 3 to add a video game ");
            Console.WriteLine();

            string opValue = Console.ReadLine();

            while (!validateOperationValue(opValue)) {
                Console.Write("This is not a valid game type. Please enter a valid option: ");
                opValue = Console.ReadLine();
            }

            return getGameTypeFromEntry(opValue);
        }

        public string getGameName() {
            
            Console.Clear();
            Console.Write("Name of the game: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please add the name of the game: ");
                value = Console.ReadLine();
            }

            return value;
        }

        public string getGameCreator() {

            Console.Clear();
            Console.Write("What company created the game: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please add what company created the game: ");
                value = Console.ReadLine();
            }

            return value;

        }

        public string getGameReleaseYear() {

            Console.Clear();
            Console.Write("Year game was release: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please add the year the game was released: ");
                value = Console.ReadLine();
            }

            return value;
        }

        public string getGameIsPlayedWhere() {

            Console.Clear();
            Console.Write("Where is the game played. Enter:\n");
            Console.Write("1 : Table\n");
            Console.Write("2 : Xbox\n");
            Console.Write("3 : Playstation\n");
            Console.Write("4 : WII\n");
            Console.Write("5 : Atari\n");
            Console.Write("6 : Other - please provide\n");

            string value = Console.ReadLine();

            if (value == "6") {
                Console.Write("Please enter the other loaction: ");
                value = Console.ReadLine();
                while (String.IsNullOrEmpty(value)) {
                    Console.WriteLine("Please enter the other loaction: ");
                    value = Console.ReadLine();
                }
                return value;
            } else {
                while (!validateGameLocation(value)) {
                    Console.Write("This is not valid game location. Please enter a valid location: ");
                    value = Console.ReadLine();
                }
                
            }

            switch (value) {
                case "1":
                    return "Table";
                case "2":
                    return "Xbox";
                case "3":
                    return "Playstation";
                case "4":
                    return "Wii";
                case "5":
                    return "Atari";
                default:
                    break;
            }
            return value;
        }

        public string getGameNumberOfPlayers() {
            
            Console.Clear();
            Console.Write("Number of players: ");
            string value = Console.ReadLine();
            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please add the number of players: ");
                value = Console.ReadLine();
            }

            return value;
        }

        public string getGameRating() {

            Console.Clear();
            Console.Write("How many starts would you rate the game (1-5): ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please add your game rating: ");
                value = Console.ReadLine();
            }

            return value;

        }

        public string getGameRatingComments() {

            Console.Clear();
            Console.Write("Comments on your rating: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please add your game rating comments: ");
                value = Console.ReadLine();
            }

            return value;

        }

        private string getGameTypeFromEntry(string option) {

            string gameType = "";
            switch (option) {
                case "1":
                    gameType = "Boardgame";
                    break;
                case "2":
                    gameType = "Cardgame";
                    break;
                case "3":
                    gameType = "Electronic";
                    break;
                default:
                    break;
            }

            return gameType;
        }


        private Boolean validateOperationValue(string op) {

            Boolean validOption = false;
            for (int i = 0; i < OperationType.Length; i++) {
                if (op.Equals(OperationType[i])) {
                    validOption = true;
                }
            }

            return validOption;
        }

        
        private Boolean validateGameLocation(string op) {

            Boolean validOption = false;
            for (int i = 0; i < GameLocation.Length; i++) {
                if (op.Equals(GameLocation[i])) {
                    validOption = true;
                }
            }

            return validOption;
        }


        private Boolean validateContinueOrEndTypes(string op) {

            Boolean validOption = false;
            for (int i = 0; i < ContinueOrEndTypes.Length; i++) {
                if (op.Equals(ContinueOrEndTypes[i])) {
                    validOption = true;
                }
            }

            return validOption;
        }


        public void printGameCollection(List<GameType> aGameList) {

            foreach (GameType theGames in aGameList) {
                Console.WriteLine(theGames.ToString());
                Console.WriteLine("       Player comments: " + theGames.Rating.ToString());
                Console.WriteLine();
            }


        }

    }
}
