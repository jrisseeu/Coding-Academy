using System;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace Activities {

    
    public class Contact {

        public int Id {
            get; set;
        }
        [JsonProperty("first_name")]
        public string FirstName {
            get; set;
        }
        [JsonProperty("last_name")]
        public string LastName {
            get; set;
        }
        public string Email {
            get; set;
        }
        public string Gender {
            get; set;
        }
        [JsonProperty("ip_address")]
        public string IpAddress {
            get; set;
        }
        public string Skill {
            get; set;
        }
        public Guid Guid { get; set; }

        public int Height { get; set; }


        public override string ToString() {

            return "First Name: " + FirstName +
                   " Last Name: " + LastName +
                   " Height: " + Height +
                   " Email: " + Email +
                   " Gender: " + Gender +
                   " IP Address: " + IpAddress +
                   " Skill: " + Skill +
                   " GUID: " + Guid;


        }


    }
}
