using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class CentreVaccinationConfig : IEntityTypeConfiguration<CentreVaccinationEntity>
    {
        public void Configure(EntityTypeBuilder<CentreVaccinationEntity> builder)
        {
            builder.Property(x => x.IsVisible)
                .HasDefaultValue(true);

            //FK
            //Entrepot 1-1
            //Horaires dans Horaire
            builder.HasMany(x => x.Horaires)
                .WithOne(x => x.Centre)
                .OnDelete(DeleteBehavior.NoAction);
            //Personnel
            builder.HasMany(x => x.Personnel)
                .WithOne(x => x.Centre)
                .OnDelete(DeleteBehavior.NoAction);
            //RDVs
            builder.HasMany(x => x.RDVs)
                .WithOne(x => x.Centre)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
