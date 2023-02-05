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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.City).HasMaxLength(55);

                entity.HasData(new Location
                {
                    Id = 1,
                    Name = "California",
                    City = "Los Angeles"
                });
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.CoachName).HasMaxLength(55);

                entity.HasData(new Team
                {
                    Id = 1,
                    Name = "UCLA Basketball",
                    CoachName = "Coach Carter"
                });
            });
        }
    }
}
