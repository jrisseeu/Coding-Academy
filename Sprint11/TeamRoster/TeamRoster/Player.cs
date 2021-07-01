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

        public void addParentOfPlayer(List<Person> aList) {

            if (null == playerParentList) {
                playerParentList = new List<Person>(4);
            }

            foreach (Person aParent in aList) {
                playerParentList.Add(aParent);

            }

        }


        public Player(int aPersonId, Boolean theFeesPaid, string aFirstName, string aLastName) : base(aPersonId, aFirstName, aLastName, "Player") {

            feesPaid = theFeesPaid;

        }

    }
}
