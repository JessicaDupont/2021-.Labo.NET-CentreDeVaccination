using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.Models;
using CentreDeVaccination.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Mapping
{
    public class CentreDeVaccinationMapping : IMapping<CentreVaccinationEntity, ICentreDeVaccination>
    {
        public CentreVaccinationEntity Mapping(ICentreDeVaccination model)
        {
            throw new NotImplementedException();
        }

        public ICentreDeVaccination Mapping(CentreVaccinationEntity entity)
        {
            ICentreDeVaccination result = new Centre();
            result.Id = entity.Id;

            EntrepotMapping eM = new EntrepotMapping();
            result.Entrepot = eM.Mapping(entity.Entrepot);

            HoraireMapping hM = new HoraireMapping();
            IList<IHoraire> r = new List<IHoraire>();
            foreach (HoraireEntity h in entity.Horaires)
            {
                r.Add(hM.Mapping(h));
            }
            result.Horaire = r;

            return result;
        }
    }
}
