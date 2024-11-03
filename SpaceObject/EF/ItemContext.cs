using Microsoft.EntityFrameworkCore;
using SpaceObject.EF;
using SpaceObject.Entities;

namespace DockerAspNetFile.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<SpaceItem> spaceItems { get; set; } = null!;
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpaceItemConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
