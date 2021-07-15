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
                GetHoraire(1), GetHoraire(2), GetHoraire(3), GetHoraire(4), GetHoraire(5), 
                GetHoraire(6), GetHoraire(7), GetHoraire(8), GetHoraire(9), GetHoraire(10));
        }

        private HoraireEntity GetHoraire(int id)
        {
            HoraireEntity result = new HoraireEntity();
            result.Id = id;

            List<string> Jours = new List<string> { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            result.Jour = Lorem.IpsumListe(Jours);

            result.Ouverture = Lorem.IpsumHeure(6, 12);
            result.Fermeture = Lorem.IpsumHeure(13, 19);
            result.DureePlageVaccination = Lorem.IpsumDureeMinutes(1,6 * 60);
            result.NbVaccinationParPlage = result.DureePlageVaccination.Minutes;
            result.CentreId = Lorem.IpsumInt(1,10);
            return result;
        }
    }
}
