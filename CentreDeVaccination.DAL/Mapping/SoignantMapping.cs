using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Mapping
{
    public class SoignantMapping : IMapping<PersonnelEntity, ISoignant>
    {
        public PersonnelEntity Mapping(ISoignant model)
        {
            throw new NotImplementedException();
        }

        public ISoignant Mapping(PersonnelEntity entity)
        {
            ISoignant result = new Soignant();
            result.Id = entity.Id;
            result.Grade = (Grades)Enum.Parse(typeof(Grades), entity.Grade);
            result.Inami = entity.NumInami;
            result.Nom = entity.Utilisateur?.Nom;
            result.Prenom = entity.Utilisateur?.Prenom;
            result.Email = entity.Utilisateur?.Email;
            return result;
        }
    }
}
