using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.DB.Entities;
using System;
using CentreDeVaccination.Models;
using CentreDeVaccination.DAL.Mapping.Bases;

namespace CentreDeVaccination.DAL.Mapping
{
    public class EntrepotMapping : IMapping<EntrepotEntity, IEntrepot>
    {
        public EntrepotEntity Mapping(IEntrepot model)
        {
            throw new NotImplementedException();
        }

        public IEntrepot Mapping(EntrepotEntity entity)
        {
            IEntrepot result = new Entrepot();
            result.Id = entity.Id;
            result.Nom = entity.Nom;
            result.Adresse = new Adresse();
            result.Adresse.Id = entity.AdresseId;
            return result;
        }
    }
}