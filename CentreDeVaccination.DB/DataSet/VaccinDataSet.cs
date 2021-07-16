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
    public class VaccinDataSet : IEntityTypeConfiguration<VaccinEntity>
    {
        public void Configure(EntityTypeBuilder<VaccinEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3)
                );
        }

        private VaccinEntity GetDonnee(int id)
        {
            VaccinEntity result = new VaccinEntity();
            result.Id = id;
            result.Fabricant = LoremIpsum.GetString(5, 10, true, false, false);
            result.Nom = result.Fabricant;
            result.NbJoursIntervalleMinimum = LoremIpsum.GetInt(15, 30);
            result.NbJoursIntervalleMaximum = LoremIpsum.GetInt(45, 60);
            return result;
        }
    }
}
