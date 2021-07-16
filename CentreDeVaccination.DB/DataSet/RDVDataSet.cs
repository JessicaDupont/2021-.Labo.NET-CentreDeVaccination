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
    public class RDVDataSet : IEntityTypeConfiguration<RendezVousEntity>
    {
        public void Configure(EntityTypeBuilder<RendezVousEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5),
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10),
                GetDonnee(11), GetDonnee(12), GetDonnee(13), GetDonnee(14), GetDonnee(15)
                );
        }

        private RendezVousEntity GetDonnee(int id)
        {
            RendezVousEntity result = new RendezVousEntity();
            result.Id = id;
            result.PatientId = id;
            result.CentreId = (id % 2) + 1;
            result.VaccinId = (id % 3) + 1;
            result.PersonnelId = (id % 5) + 3;
            result.LotId = LoremIpsum.GetInt(1, 10);
            result.RendezVous = LoremIpsum.GetDate(DateTime.Now.Year, DateTime.Now.Year);
            return result;
        }
    }
}
