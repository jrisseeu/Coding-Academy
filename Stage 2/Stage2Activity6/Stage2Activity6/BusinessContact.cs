using System;
using CsvHelper.Configuration.Attributes;



namespace Stage2Activity6  {

        
    public class BusinessContact
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("first_name")]
        public string FirstName { get; set; }
        [Name("last_name")]
        public string LastName { get; set; }
        [Name("email")]
        public string Email { get; set; }
        [Name("gender")]
        public string Gender { get; set; }
        [Name("skill")]
        public string Skill { get; set; }
        [Name("ip_address")]
        public string IpAddress { get; set; }
        [Name("GUID")]
        public Guid GUID { get; set; }


        //public override string ToString() {
        //
          //  return "Id: " + Id +
            //        "First Name: " + FirstName +
              //     " Last Name: " + LastName +
                //   " Email: " + Email +
                  // " Gender: " + Gender +
                   //" IP Address: " + IpAddress +
                   //" Skill: " + Skill ;


        //}


    }
}
