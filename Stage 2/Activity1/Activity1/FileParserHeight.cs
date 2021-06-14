using System;
using System.IO;
using System.Linq;

namespace Activities {
    class FileParserHeight {

        string JSONfileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\ContactsWithHeight.json";
        

        public void ReadContactJsonFile() {

            var text = File.ReadAllText(JSONfileName);

            var contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<Contact[]>(text);

            //ForEachLoop(contacts);
            //DoWhileLoop(contacts);
            //WhileLoop(contacts);
            //DoWhileLoopHeightCheckOver70(contacts);
            ForEachLoopUnder68(contacts);

        }

        public void ForEachLoopUnder68(Contact[] contacts)
        {

            var newConactList = from theContact in contacts 
                                where theContact.Height > 68 
                                select theContact;

            foreach (Contact contact in newConactList)
            {
               Console.WriteLine($"{contact.FirstName} {contact.LastName} { contact.Height} ");
            }

        }

        public void DoWhileLoopHeightCheckOver70(Contact[] contacts)
        {
            var i = 0;
            do {
                
                if (contacts[i].Height > 70)
                {
                    Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} { contacts[i].Height} ");
                }
                
                i++;
               
            } while (i < contacts.Length);

        }
        public void DoWhileLoop(Contact[] contacts)
        {
            var i = 0;
            do
            {
                Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} { contacts[i].Height} ");
                i++;
            } while (i < contacts.Length);

        }
        public void WhileLoop(Contact[] contacts)
        {
            var i = 0;
            while (i < contacts.Length) {
                Console.WriteLine($"{contacts[i].FirstName} {contacts[i].LastName} { contacts[i].Height} ");
                i++;
            }

        }
        public void ForEachLoop(Contact[] contacts)
        {

            foreach (var contact in contacts) {
                Console.WriteLine($"{contact.FirstName} {contact.LastName} { contact.Height} ");
            }

        }


    }
}
