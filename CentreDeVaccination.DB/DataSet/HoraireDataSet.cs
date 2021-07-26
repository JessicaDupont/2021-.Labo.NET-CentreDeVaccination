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
            builder.HasData(GetDonnees(10));
        }

        private HoraireEntity[] GetDonnees(int nb)
        {
            HoraireEntity[] result = new HoraireEntity[nb];
            for (int i = 0; i < nb; i++)
            {
                result[i] = GetDonnee(i + 1);
            }
            return result;
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
            result.NbVaccinationParPlage = result.DureePlageVaccination.Minutes == 0 ? 1 : result.DureePlageVaccination.Minutes;
            result.CentreId = (id%2)+1;
            return result;
        }
    }
}
