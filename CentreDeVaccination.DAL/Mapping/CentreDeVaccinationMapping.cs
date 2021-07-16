using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.Models;
using CentreDeVaccination.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Repositories;

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
            return result;
        }
    }
}
