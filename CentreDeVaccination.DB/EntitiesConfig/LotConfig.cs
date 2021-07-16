using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class LotConfig : IEntityTypeConfiguration<LotEntity>
    {
        public void Configure(EntityTypeBuilder<LotEntity> builder)
        {
            //CK            
            builder.HasIndex(l => l.NumLot)
                .IsUnique();

            builder.HasCheckConstraint("CK_NbDoses", "NbDoses >= 0");

            //FK
            //Lot N - 1 Vaccin
            //builder.HasOne(x => x.VaccinId)
            //   .WithMany(y => y.Lots)
            //   .OnDelete(DeleteBehavior.Cascade);
            //RDVs voir dans RendezVous
            
            //transit
            builder.HasMany(x => x.Transits)
                .WithOne(x => x.Lot)
                .OnDelete(DeleteBehavior.NoAction);

            //lot
            builder.HasMany(x => x.RDVs)
                .WithOne(x => x.Lot)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
