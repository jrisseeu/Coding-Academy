using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class Player : Person {

        List<Person> playerParentList;
        private bool feesPaid { get; set; }

        public Player() {

        }

        public List<Person> PlayerParentList {
            get {
                return playerParentList;
            }
        }

        public void addParentOfPlayer(Person aPlayer) {

            if (null == playerParentList) {
                playerParentList = new List<Person>(4);
                playerParentList.Add(aPlayer);
            }
            else {
                playerParentList.Add(aPlayer);
            }

        }


        public Player(Boolean theFeesPaid, string aFirstName, string aLastName) : base(aFirstName, aLastName, "Player") {

            feesPaid = theFeesPaid;

        }

    }
}
