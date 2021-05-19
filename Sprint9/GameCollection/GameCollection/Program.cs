using System;
using System.Collections.Generic;

namespace GameCollection {
    class Program {
        static void Main(string[] args) {

            // GameType aGame = new GameType();
            // aGame.Type = "Electronic";
            //aGame.Platform = "Console";
            //aGame.NumberOfPlayers = "2";
            //aGame.Name = "Pong";
            //aGame.YearCreated = "1972";
            //aGame.CreatedBy = "Atari";
            //Console.WriteLine(aGame.ToString());

            //GameType aGame2 = new GameType("Board", "table", "6", "Monopoly", "1950", "Hasboro");
            //Console.WriteLine(aGame2.ToString());


            Console.Write("Enter game collection information ");
            Console.WriteLine("\n"); // Friendly linespacing.
            Boolean keepGoing = true;

            List<GameType> gameList = new List<GameType>();

            while (keepGoing) {

                string gameType = "";
                Console.WriteLine("Enter 1 to add a board Game ");
                Console.WriteLine("Enter 2 to add a card game ");
                Console.WriteLine("Enter 3 to add a video game ");
                string option = Console.ReadLine();
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

                Console.Write("Name of the game: ");
                string gameName = Console.ReadLine();

                Console.Write("What company created the game: ");
                string createdBy = Console.ReadLine();

                Console.Write("Year game was release: ");
                string yrCreated = Console.ReadLine();

                Console.Write("Where is the game played: ");
                string platform = Console.ReadLine();

                Console.Write("Number of players: ");
                string nrOfPlayers = Console.ReadLine();

                Console.Write("How many starts would you rate the game (1-5) ");
                string stars = Console.ReadLine();
                Console.Write("Comments on your rating ");
                string comments = Console.ReadLine();

                GameType aGame = new GameType(gameType, platform, nrOfPlayers, gameName, yrCreated, createdBy);
                aGame.rating = new GameRating(stars, comments);
                gameList.Add(aGame);


                Console.WriteLine("Enter 1 to continue");
                Console.WriteLine("Enter 2 to see game info");
                Console.WriteLine("Enter 3 to display and leave");

                string next = Console.ReadLine();
                switch (next) {
                    case "1":
                        break;
                    case "2":
                        Console.WriteLine("\n"); // Friendly linespacing.  
                        foreach (GameType theGames in gameList) {
                            Console.WriteLine(theGames.ToString());
                            Console.WriteLine("       Player comments: " +theGames.rating.ToString());
                        }
                        Console.WriteLine("\n"); // Friendly linespacing.  
                        break;
                    case "3":
                        keepGoing = false;
                        Console.WriteLine("\n"); // Friendly linespacing.  
                        foreach (GameType theGames in gameList) {
                            Console.WriteLine(theGames.ToString());
                            Console.WriteLine("       Player comments: " + theGames.rating.ToString());
                        }
                        Console.WriteLine("\n"); // Friendly linespacing.  
                        break;
                    default:
                        break;
                }

            }

        }
    }
}
