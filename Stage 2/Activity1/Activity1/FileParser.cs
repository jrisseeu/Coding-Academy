using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Activities {
    class FileParser {

        string JSONfileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Contacts.json";
        string XMLfileName = "C:\\Coding-Academy\\Stage 2\\DataFiles\\Contacts.xml";

        public void ReadContactJsonFile() {

            var text = File.ReadAllText(JSONfileName);

            var contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<Contact[]>(text);

            foreach (var contact in contacts) {
                //Console.WriteLine(contact.FirstName + " " + contact.LastName +" " +contact.IpAddress );
                Console.WriteLine(contact.ToString());

            }
        }

        public void ReadContactXmlFile() {

            try {

                FileStream stream = File.Open(XMLfileName, FileMode.Open, FileAccess.Read);
                //List<Contact> result = (List<Contact>)(new XmlSerializer(typeof(List<Contact>))).Deserialize(stream);
                // OR 
                Contact[] result = (Contact[])(new XmlSerializer(typeof(Contact[]))).Deserialize(stream);

                foreach (var contact in result) {
                    //Console.WriteLine(contact.FirstName + " " + contact.LastName +" " +contact.IpAddress );
                    Console.WriteLine(contact.ToString());

                }
            }
            catch (Exception e) {
                Console.WriteLine("Exception error: " + e.ToString());

            }
        }
    }
}
