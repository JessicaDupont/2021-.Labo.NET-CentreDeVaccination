using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.IModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class PersonnelConfig : IEntityTypeConfiguration<PersonnelEntity>
    {
        public void Configure(EntityTypeBuilder<PersonnelEntity> builder)
        {
            builder.Property(x => x.ResponsableCentre)
                .HasDefaultValue(false);
            builder.Property(x => x.IsVisible)
                .HasDefaultValue(true);

            //CK
            builder.HasCheckConstraint("CK_Grade",
                "Grade in ('"+Grades.Medecin+ "', '" 
                + Grades.Infirmier + "', '" 
                + Grades.Securite + "', '" 
                + Grades.Benevole + "')");

            builder.HasCheckConstraint("CK_NumInami", "NumInami LIKE '___________'");//11caractères

            //FK

            //utilisateur

            //builder.HasOne(p => p.CentreId)
            //    .WithMany(c => c.Personnel)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //RDVs
            builder.HasMany(x => x.RDVs)
                .WithOne(x => x.Personnel)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
