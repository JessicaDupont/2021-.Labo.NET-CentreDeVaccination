using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
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
    public class AdresseDataSet : IEntityTypeConfiguration<AdresseEntity>
    {
        public void Configure(EntityTypeBuilder<AdresseEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5),
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10),
                GetDonnee(11), GetDonnee(12), GetDonnee(13), GetDonnee(14), GetDonnee(15),
                GetDonnee(16), GetDonnee(17), GetDonnee(18), GetDonnee(19), GetDonnee(20),
                GetDonnee(21), GetDonnee(22), GetDonnee(23), GetDonnee(24), GetDonnee(25)
                );
        }

        private AdresseEntity GetDonnee(int id)
        {
            AdresseEntity result = new AdresseEntity();
            result.Id = id;
            result.Rue = LoremIpsum.GetString(16, true, true, false);
            result.Numero = LoremIpsum.GetInt()+"";
            result.CodePostal = LoremIpsum.GetInt(1000, 9999);
            result.Ville = LoremIpsum.GetString(8, true, false, false); ;
            return result;
        }
    }
}
