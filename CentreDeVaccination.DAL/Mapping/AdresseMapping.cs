using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;

namespace CentreDeVaccination.DAL.Mapping
{
    public class AdresseMapping : IMapping<AdresseEntity, IAdresse>
    {
        public AdresseEntity Mapping(IAdresse model)
        {
            throw new System.NotImplementedException();
        }

        public IAdresse Mapping(AdresseEntity entity)
        {
            IAdresse result = new Adresse();
            result.Id = entity.Id;
            result.Rue = entity.Rue;
            result.Numero = entity.Numero;
            result.CodePostal = entity.CodePostal;
            result.Ville = entity.Ville;
            return result;
        }
    }
}