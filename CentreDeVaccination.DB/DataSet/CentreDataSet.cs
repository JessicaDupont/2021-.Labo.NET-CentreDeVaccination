using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DB.DataSet
{
    public class CentreDataSet : IEntityTypeConfiguration<CentreVaccinationEntity>
    {
        public void Configure(EntityTypeBuilder<CentreVaccinationEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2));
        }

        private CentreVaccinationEntity GetDonnee(int id)
        {
            CentreVaccinationEntity result = new CentreVaccinationEntity();
            result.Id = id;
            result.EntrepotId = id;
            return result;
        }
    }
}
