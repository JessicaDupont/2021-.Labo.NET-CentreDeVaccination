using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
using System;

namespace CentreDeVaccination.DAL.Mapping
{
    public class PersonneMapping : IMapping<UtilisateurEntity, IPersonne>
    {
        public UtilisateurEntity Mapping(IPersonne model)
        {
            throw new NotImplementedException();
        }

        public IPersonne Mapping(UtilisateurEntity entity)
        {
            IPersonne result = new Personne();
            result.Id = entity.Id;
            result.Nom = entity.Nom;
            result.Prenom = entity.Prenom;
            return result;
        }
    }
}