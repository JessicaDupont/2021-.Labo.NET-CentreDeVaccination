
using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class RendezVousConfig : IEntityTypeConfiguration<RendezVousEntity>
    {
        public void Configure(EntityTypeBuilder<RendezVousEntity> builder)
        {
            //FK

            //patient 1-1
            //builder.HasOne(r => r.VaccinId)
            //    .WithMany(v => v.RDVs)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //builder.HasOne(r => r.LotId)
            //    .WithMany(v => v.RDVs)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //builder.HasOne(r => r.CentreId)
            //    .WithMany(c => c.RDVs)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(r => r.PatientId)
            //    .WithMany(v => v.RDVs)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(r => r.PersonnelId)
            //    .WithMany(v => v.RDVs)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

        }

    }
}
