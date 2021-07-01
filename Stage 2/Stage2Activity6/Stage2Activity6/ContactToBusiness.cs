using CsvHelper.Configuration.Attributes;


namespace Stage2Activity6
{

    
    public class ContactToBusiness
    {

      
        [Name("contact_id")]
        public int ContactId { get; set; }
        [Name("business_id")]
        public int BusinessId { get; set; }


        public override string ToString() {

            return " ContactId: " + ContactId +
                " BusinessId: " + BusinessId;

        }


    }
}
