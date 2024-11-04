using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpaceObject.Entities;

namespace SpaceObject.EF
{
    public class AsteroidItemConfig : IEntityTypeConfiguration<AsteroidItem>
    {
        public void Configure(EntityTypeBuilder<AsteroidItem> builder)
        {
            builder.ToTable("asteroid_items").HasKey(ai => ai.id);
            builder.HasOne(ai => ai.asteroidProperty).WithOne(ap => ap.asteroidItem).HasForeignKey<AsteroidProperty>(ap => ap.idAsteroidItem).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
