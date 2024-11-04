using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpaceObject.Entities;

namespace SpaceObject.EF
{
    public class AsteroidPropertyConfig : IEntityTypeConfiguration<AsteroidProperty>
    {
        public void Configure(EntityTypeBuilder<AsteroidProperty> builder)
        {
            builder.ToTable("asteroid_properties").HasKey(ap => ap.id);
            builder.Property(ap => ap.idAsteroidItem).HasColumnName("FK_IdAsteroidItem");
            builder.HasIndex(ap => ap.idAsteroidItem).IsUnique().HasDatabaseName("IX_AsteroidProperty_idAsteroidItem");
        }
    }
}
