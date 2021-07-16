using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolIca.LoremIpsum;

namespace CentreDeVaccination.DB.DataSet
{
    public class HoraireDataSet : IEntityTypeConfiguration<HoraireEntity>
    {
        public void Configure(EntityTypeBuilder<HoraireEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5), 
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10));
        }

        private HoraireEntity GetDonnee(int id)
        {
            HoraireEntity result = new HoraireEntity();
            result.Id = id;

            List<string> Jours = new List<string> { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            result.Jour = LoremIpsum.GetListe(Jours);

            result.Ouverture = LoremIpsum.GetHeureMinutes(6, 12);
            result.Fermeture = LoremIpsum.GetHeureMinutes(13, 19);
            result.DureePlageVaccination = LoremIpsum.GetDureeMinutes(1,6 * 60);
            result.NbVaccinationParPlage = result.DureePlageVaccination.Minutes;
            result.CentreId = LoremIpsum.GetInt(1,2);
            return result;
        }
    }
}
