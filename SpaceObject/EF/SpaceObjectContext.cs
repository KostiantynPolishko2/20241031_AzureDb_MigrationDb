using Microsoft.EntityFrameworkCore;
using SpaceObject.Entities;

namespace SpaceObject.EF
{
    public class SpaceObjectContext : DbContext
    {
        public DbSet<AsteroidItem> asteroidItems { get; set; } = null!;
        public DbSet<AsteroidProperty> asteroidProperties { get; set; } = null!;

        public SpaceObjectContext(DbContextOptions<SpaceObjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AsteroidItemConfig());
            modelBuilder.ApplyConfiguration(new AsteroidPropertyConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
