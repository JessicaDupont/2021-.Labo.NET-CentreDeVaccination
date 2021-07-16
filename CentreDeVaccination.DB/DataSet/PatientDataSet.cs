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
    public class PatientDataSet : IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5),
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10),
                GetDonnee(11), GetDonnee(12), GetDonnee(13), GetDonnee(14), GetDonnee(15),
                GetDonnee(16), GetDonnee(17), GetDonnee(18), GetDonnee(19), GetDonnee(20)
                );
        }

        private PatientEntity GetDonnee(int id)
        {
            PatientEntity result = new PatientEntity();
            result.Id = id;
            result.UtilisateurId = id;
            result.AdresseId = id;
            result.NumTelephone = "0"+LoremIpsum.GetString(1,3)
                +"/"+LoremIpsum.GetString(6, 9, false, true, false);
            result.InformationMedicales = LoremIpsum.GetParagraphe();
            result.NumRegNat = LoremIpsum.GetString(2, false, true, false)
                +"."+ LoremIpsum.GetString(2, false, true, false)
                +"."+ LoremIpsum.GetString(2, false, true, false)
                +"-"+ LoremIpsum.GetString(3, false, true, false)
                +"."+ LoremIpsum.GetString(2, false, true, false);
            return result;
        }
    }
}
