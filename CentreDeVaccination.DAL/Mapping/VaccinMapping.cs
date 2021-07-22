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
    public class VaccinMapping : IMapping<VaccinEntity, IVaccin>
    {
        public VaccinEntity Mapping(IVaccin model)
        {
            throw new NotImplementedException();
        }

        public IVaccin Mapping(VaccinEntity entity)
        {
            IVaccin result = new Vaccin();
            result.Id = entity.Id;
            result.IntervalleMin = new TimeSpan(entity.NbJoursIntervalleMinimum, 0, 0, 0);
            result.IntervalleMax = new TimeSpan(entity.NbJoursIntervalleMaximum, 0, 0, 0);
            result.Nom = entity.Nom;
            result.Fabricant = entity.Fabricant;
            return result;
        }
    }
}
