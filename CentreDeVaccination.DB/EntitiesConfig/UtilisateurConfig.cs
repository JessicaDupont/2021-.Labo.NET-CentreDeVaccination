
using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class UtilisateurConfig : IEntityTypeConfiguration<UtilisateurEntity>
    {
        public void Configure(EntityTypeBuilder<UtilisateurEntity> builder)
        {
            builder.Property(u => u.Email)
                .IsUnicode(false);

            builder.HasCheckConstraint("CK_Email", "Email like '_%@_%'")
                .HasIndex(u => u.Email)
                .IsUnique();

            //FK
            //Patient voir Patient
        }

    }
}
