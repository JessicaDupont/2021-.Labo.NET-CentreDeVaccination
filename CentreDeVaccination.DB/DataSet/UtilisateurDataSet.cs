using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolIca.LoremIpsum;
using ToolIca.Securite;

namespace CentreDeVaccination.DB.DataSet
{
    public class UtilisateurDataSet : IEntityTypeConfiguration<UtilisateurEntity>
    {
        public void Configure(EntityTypeBuilder<UtilisateurEntity> builder)
        {
            builder.HasData(
                GetDonnee(1), GetDonnee(2), GetDonnee(3), GetDonnee(4), GetDonnee(5),
                GetDonnee(6), GetDonnee(7), GetDonnee(8), GetDonnee(9), GetDonnee(10),
                GetDonnee(11), GetDonnee(12), GetDonnee(13), GetDonnee(14), GetDonnee(15),
                GetDonnee(16), GetDonnee(17), GetDonnee(18), GetDonnee(19), GetDonnee(20)
                );
        }

        private UtilisateurEntity GetDonnee(int id)
        {
            UtilisateurEntity result = new UtilisateurEntity();
            result.Id = id;
            result.Nom = LoremIpsum.GetString(5, 10, true, false, false);
            result.Prenom = LoremIpsum.GetString(3, 7, true, false, false);
            result.Email = LoremIpsum.GetEmail();
            result.MotDePasse = Cryptage.MotDePasseSHA512(result.Nom);
            return result;
        }
    }
}
