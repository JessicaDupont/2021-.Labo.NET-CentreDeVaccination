using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class EntrepotConfig : IEntityTypeConfiguration<EntrepotEntity>
    {
        public void Configure(EntityTypeBuilder<EntrepotEntity> builder)
        {
            //FK
            //Adresse 1-1
            //Transit
            builder.HasMany(t => t.Transits)
                .WithOne(i => i.EntrepotId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
