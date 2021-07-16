using CentreDeVaccination.DB.Entities;
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
    public class PersonnelDataSet : IEntityTypeConfiguration<PersonnelEntity>
    {
        public void Configure(EntityTypeBuilder<PersonnelEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5),
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10),
                GetDonnee(11), GetDonnee(12), GetDonnee(13), GetDonnee(14), GetDonnee(15)
                );
        }

        private PersonnelEntity GetDonnee(int id)
        {
            PersonnelEntity result = new PersonnelEntity();

            result.Id = id;
            result.UtilisateurId = id;
            result.CentreId = (id%2)+1;
            result.ResponsableCentre = false;
            if (id <= 2)
            {
                result.Grade = Grades.Medecin.ToString();
                result.ResponsableCentre = true;
                result.NumInami = LoremIpsum.GetString(11, false, true, false);
            }
            else if (id <= 7)
            {
                result.Grade = Grades.Infirmier.ToString();
                result.NumInami = LoremIpsum.GetString(11, false, true, false);
            }
            else if (id <= 10)
            {
                result.Grade = Grades.Securite.ToString();
            }
            else 
            {
                result.Grade = Grades.Benevole.ToString();
            }

            return result;
        }

    }
}
