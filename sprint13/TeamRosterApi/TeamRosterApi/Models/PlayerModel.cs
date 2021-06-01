using System.ComponentModel.DataAnnotations;

namespace TeamRosterApi {
    public class PlayerModel {

        [Key]
        public int playerId { get; set;}
        public int teamId { get; set; }
        public string playerFname {get; set;}
        public string playerLname {get; set;}
              


    }
        
}
