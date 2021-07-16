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
    public class EntrepotDataSet : IEntityTypeConfiguration<EntrepotEntity>
    {
        public void Configure(EntityTypeBuilder<EntrepotEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5));
        }

        private EntrepotEntity GetDonnee(int id)
        {
            EntrepotEntity result = new EntrepotEntity();
            result.Id = id;
            result.Nom = LoremIpsum.GetString(10, 20, true, false, false);
            result.AdresseId = id+20;
            return result;
        }
    }
}
