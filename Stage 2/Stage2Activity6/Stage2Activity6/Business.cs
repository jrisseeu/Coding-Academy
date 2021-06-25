using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;


namespace Stage2Activity6
{

    
    public class Business {
        [Name("id")]
        public int Id { get; set; }
        [Name("name")]
        public string Name { get; set; }


        public List<BusinessContact> Contacts { get; private set; } = new List<BusinessContact>();

        public override string ToString() {

            return " Id: " + Id +
                " Name: " + Name +
                " Contact size: " + Contacts.Count;

        }


        public void addContact(BusinessContact aCtc)
        {

            if (Contacts == null) {

                Contacts = new List<BusinessContact>();
                Contacts.Add(aCtc);
            }
            Contacts.Add(aCtc);

        }



    }
}
