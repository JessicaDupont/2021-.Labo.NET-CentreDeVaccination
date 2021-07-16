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
    public class LotDataSet : IEntityTypeConfiguration<LotEntity>
    {
        public void Configure(EntityTypeBuilder<LotEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5),
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10)
                );
        }

        private LotEntity GetDonnee(int id)
        {
            LotEntity result = new LotEntity();
            result.Id = id;
            result.NumLot = LoremIpsum.GetString(4, 10, false, true, false);
            result.VaccinId = (id % 3) + 1;
            result.NbDoses = LoremIpsum.GetInt(10,100);
            result.NbDosesRestantes = result.NbDoses;
            return result;
        }
    }
}
