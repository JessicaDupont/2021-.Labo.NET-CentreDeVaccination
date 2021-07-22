using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;

namespace CentreDeVaccination.DAL.Mapping
{
    public class HoraireMapping : IMapping<HoraireEntity, IHoraire>
    {
        public HoraireEntity Mapping(IHoraire model)
        {
            throw new System.NotImplementedException();
        }

        public IHoraire Mapping(HoraireEntity entity)
        {
            IHoraire result = new Horaire();
            result.Id = entity.Id;
            result.Jour = entity.Jour;
            result.Ouverture = entity.Ouverture;
            result.Fermeture = entity.Fermeture;
            result.OuvertureBis = entity.OuvertureBis;
            result.FermetureBis = entity.FermetureBis;
            result.DureePlageVaccination = entity.DureePlageVaccination;
            result.NbVaccinationParPlage = entity.NbVaccinationParPlage;
            return result;
        }
    }
}