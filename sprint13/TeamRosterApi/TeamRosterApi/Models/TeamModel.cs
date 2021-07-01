using System.ComponentModel.DataAnnotations;

namespace TeamRosterApi {

    public class TeamModel {
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