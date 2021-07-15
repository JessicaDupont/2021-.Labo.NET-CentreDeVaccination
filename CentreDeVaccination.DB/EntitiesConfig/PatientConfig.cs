using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class PatientConfig : IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.HasCheckConstraint("CK_NumRegNat",
                "NumRegNat LIKE '__.__.__-___.__'");

            builder.HasCheckConstraint("CK_NumTelephone",
                "NumTelephone LIKE '0_%/______%'");

            //FK
            //utilisateur 1-1
            //adresse 1-1
            //Personnel voir Personnel
            //RDVs
            builder.HasMany(x => x.RDVs)
                .WithOne(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
