using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.DB.Entities;
using System;
using CentreDeVaccination.Models;

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
            //adresse
            AdresseMapping aM = new AdresseMapping();
            result.Adresse = aM.Mapping(entity.Adresse);
            //liste des vaccins disponibles
            result.Vaccins = null;//TODO

            return result;
        }
    }
}