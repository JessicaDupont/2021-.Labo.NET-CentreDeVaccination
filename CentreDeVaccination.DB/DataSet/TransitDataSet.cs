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
    public class TransitDataSet : IEntityTypeConfiguration<TransitEntity>
    {
        public void Configure(EntityTypeBuilder<TransitEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5),
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10)
                );
        }

        private TransitEntity GetDonnee(int id)
        {
            TransitEntity result = new TransitEntity();

            result.Id = id;
            result.LotId = id;
            result.EntrepotId = ((id-1) / 2)+1;
            result.DateEntree = LoremIpsum.GetDate(DateTime.Now.Year-1, DateTime.Now.Year);

            return result;
        }
    }
}
