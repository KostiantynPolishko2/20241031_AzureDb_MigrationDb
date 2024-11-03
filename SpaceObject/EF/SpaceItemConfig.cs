using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpaceObject.Entities;

namespace SpaceObject.EF
{
    public class SpaceItemConfig : IEntityTypeConfiguration<SpaceItem>
    {
        public void Configure(EntityTypeBuilder<SpaceItem> builder)
        {
            builder.ToTable("spaceitems").HasKey(c => c.item_id);
        }
    }
}
