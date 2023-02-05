using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Data
{
    public class MatchDataDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Team> Teams { get; set; }

        public MatchDataDbContext(DbContextOptions<MatchDataDbContext> options) 
            : base(options) 
        {

        }
    }
}
