using System.ComponentModel.DataAnnotations;


namespace TeamRosterApi {
    public class ParentModel {

        [Key]
        public int parentId {  get; set;  }
        public int playerId { get; set; }
        public string parentFname { get; set; }
        public string parentLname { get; set; }
        public string roleTypeParent { get; set; }
    }
        
}
