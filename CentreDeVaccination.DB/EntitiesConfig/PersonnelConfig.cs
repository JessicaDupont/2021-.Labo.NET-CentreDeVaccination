using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class PersonnelConfig : IEntityTypeConfiguration<PersonnelEntity>
    {
        public void Configure(EntityTypeBuilder<PersonnelEntity> builder)
        {
            builder.HasCheckConstraint("CK_Grade",
                "Grade in ('Medecin', 'Infirmier', 'Sécurité', 'Bénévole')");

            builder.HasCheckConstraint("CK_NumInami", "NumInami LIKE '_-_-____-__-___'");

            //FK

            //Patient 1-1
            //builder.HasOne(p => p.CentreId)
            //    .WithMany(c => c.Personnel)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //RDVs
            builder.HasMany(x => x.RDVs)
                .WithOne(x => x.PersonnelId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
