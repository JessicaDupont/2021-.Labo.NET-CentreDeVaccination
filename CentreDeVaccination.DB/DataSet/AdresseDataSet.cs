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
                GetAdresse(1), GetAdresse(2), GetAdresse(3), GetAdresse(4), GetAdresse(5), 
                GetAdresse(6), GetAdresse(7), GetAdresse(8), GetAdresse(9), GetAdresse(10));
        }

        private AdresseEntity GetAdresse(int id)
        {
            AdresseEntity result = new AdresseEntity();
            result.Id = id;
            result.Rue = Lorem.IpsumString(16);
            result.Numero = Lorem.IpsumInt()+"";
            result.CodePostal = Lorem.IpsumInt(1000, 9999);
            result.Ville = Lorem.IpsumString(8);
            return result;
        }
    }
}
