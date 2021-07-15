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
            //FK
            //Entrepot 1-1
            //Responsable 1-1
            //Horaires dans Horaire
            builder.HasMany(x => x.Horaires)
                .WithOne(x => x.CentreId)
                .OnDelete(DeleteBehavior.Cascade);
            //Personnel dans Personnel
            builder.HasMany(x => x.RDVs)
                .WithOne(x => x.CentreId)
                .OnDelete(DeleteBehavior.SetNull);
            //RDVs dans RendezVous
            builder.HasMany(x => x.RDVs)
                .WithOne(x => x.CentreId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
