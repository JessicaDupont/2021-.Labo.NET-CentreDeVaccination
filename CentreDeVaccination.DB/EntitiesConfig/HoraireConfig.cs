using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class HoraireConfig : IEntityTypeConfiguration<HoraireEntity>
    {
        public void Configure(EntityTypeBuilder<HoraireEntity> builder)
        {
            builder.Property(x => x.IsVisible)
                .HasDefaultValue(true);

            //CK
            builder.HasCheckConstraint("CK_Jour",
                "Jour in ('Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi', 'Dimanche')");
            builder.HasCheckConstraint("CK_Fermeture",
                "Fermeture > Ouverture");
            builder.HasCheckConstraint("CK_OuvertureBis",
                "OuvertureBis >= Fermeture");
            builder.HasCheckConstraint("CK_FermetureBis",
                "FermetureBis > OuvertureBis");
            //builder.HasCheckConstraint("CK_DureePlageVaccination",
            //    "DureePlageVaccination <= (Fermeture-Ouverture) " +
            //    "OR " +
            //    "DureePlageVaccination <= (FermetureBis-OuvertureBis)");
            builder.HasCheckConstraint("CK_NbVaccination",
                "NbVaccinationParPlage > 0");

            //FK
            //Centre 1 - N horaire
            //builder.HasOne(h => h.CentreId)
            //    .WithMany(c => c.Horaires)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
