using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class TeamRosterView {

        private string[] OperationType = { "1", "2", "3", "4" };

        public TeamRosterView() {
        }


        public void startTeamRoster() {

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Welcome to your team roster collection and printing  ");
            Console.WriteLine("-----------------------------------------------------");
        }


        public string getTeamName() {

            Console.Write("What is the name of the Team: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please provide the team name: ");
                value = Console.ReadLine();

            }

            return value;

        }

        public string getTeamSport() {

            Console.Clear();
            Console.Write("What is the sport the team is playing: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please provide the sport: ");
                value = Console.ReadLine();

            }

            return value;

        }

        public string getTeamSeason() {

            Console.Clear();
            Console.Write("What season is the sport playing in: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please provide the season: ");
                value = Console.ReadLine();

            }

            return value;

        }


        public string getPlayerFirstNm() {

            Console.Write("What is the players first name: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please provide the player first Name: ");
                value = Console.ReadLine();

            }

            return value;

        }

        public string getPlayerLastNm() {

            Console.Clear();
            Console.Write("What is the players last name: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please provide the player last Name: ");
                value = Console.ReadLine();

            }

            return value;

        }

        public string getParentFirstNm() {

            Console.Clear();
            Console.Write("What is the Parent first name: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please provide the Parent first Name: ");
                value = Console.ReadLine();

            }

            return value;

        }

        public string getParentLastNm() {

            Console.Clear();
            Console.Write("What is the Parent last name: ");
            string value = Console.ReadLine();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Please provide the Parent last Name: ");
                value = Console.ReadLine();

            }

            return value;

        }

        public bool addParentToStudent() {

            Console.Clear();
            Console.Write("Add parent information?   ");
            Console.Write("Enter Y to add ");
            string value = Console.ReadLine().ToUpper();

            while (String.IsNullOrEmpty(value)) {
                Console.Write("Do you have parent information? ");
                value = Console.ReadLine().ToUpper();
            }

            if (value == "Y") {
                return true;
            }
            else {
                return false;
            }

        }

        public string addAnotherPlayer() {

            Console.WriteLine("Enter 1 to add another player ");
            Console.WriteLine("Enter 2 to print the roster and add more ");
            Console.WriteLine("Enter 3 to print the roster and quit ");
            Console.WriteLine("Enter 4 to quit ");
            Console.WriteLine();

            string opValue = Console.ReadLine();

            while (!validateOperationValue(opValue)) {
                Console.Write("This is not valid operation. Please enter a valid option: ");
                opValue = Console.ReadLine();
            }

            return opValue;

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

        public void printRosterInfo(TeamInfo theTeam) {

            Console.Clear();
            Console.WriteLine(theTeam.ToString());

            //Print the player
            foreach (Person aPlayer in theTeam.PlayerList) {
                Console.WriteLine(aPlayer.ToString());

            }

            //Print the player
            foreach (Person aParent in theTeam.PlayerParentList) {
                Console.WriteLine(aParent.ToString());

            }
        }



    }
}
