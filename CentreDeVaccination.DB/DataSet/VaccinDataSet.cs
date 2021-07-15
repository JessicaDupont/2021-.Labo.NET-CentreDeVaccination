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
                GetVaccin(1), GetVaccin(2), GetVaccin(3), GetVaccin(4), GetVaccin(5));
        }

        private VaccinEntity GetVaccin(int id)
        {
            VaccinEntity result = new VaccinEntity();
            result.Id = id;
            result.Fabricant = Lorem.IpsumString(5, 10);
            result.Nom = result.Fabricant;
            result.IntervalleMinimum = Lorem.IpsumDureeJours(15, 30);
            result.IntervalleMaximum = Lorem.IpsumDureeJours(45, 60);
            return result;
        }
    }
}
