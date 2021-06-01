
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace TeamRosterApi {
    public class TeamAndRosterModel {

        [Key]
        public int teamId {
            get; set;
        }
        public string teamName {
            get; set;
        }
        public string sportName {
            get; set;
        }

        public string season {
            get; set;
        }

        


    }
}
