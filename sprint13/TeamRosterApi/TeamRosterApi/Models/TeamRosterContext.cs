using Microsoft.EntityFrameworkCore;
using TeamRosterApi;

namespace TeamRosterApi.Models {
    public class TeamRosterContext : DbContext {
        public TeamRosterContext(DbContextOptions<TeamRosterContext> options)
            : base(options) {
        }

        public DbSet<TeamAndRosterModel> TeamInfo {
            get; set;
        }

        public DbSet<TeamRosterApi.ParentModel> ParentModel { get; set; }

        public DbSet<TeamRosterApi.PlayerModel> PlayerModel { get; set; }

        public DbSet<TeamRosterApi.TeamModel> TeamModel { get; set; }
    }
}