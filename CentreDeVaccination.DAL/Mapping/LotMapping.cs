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
    public class LotMapping : IMapping<LotEntity, ILot>
    {
        public LotEntity Mapping(ILot model)
        {
            throw new NotImplementedException();
        }

        public ILot Mapping(LotEntity entity)
        {
            ILot result = new Lot();
            result.Id = entity.Id;
            result.NumLot = entity.NumLot;
            result.QtDoses = entity.NbDoses;
            result.QtDosesRestantes = entity.NbDosesRestantes;
            result.Vaccin = new Vaccin();
            result.Vaccin.Id = entity.VaccinId;
            return result;
        }
    }
}
