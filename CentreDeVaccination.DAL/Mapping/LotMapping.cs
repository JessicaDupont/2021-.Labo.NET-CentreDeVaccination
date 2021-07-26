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
        private readonly VaccinMapping vaccinMap;

        public LotMapping()
        {
            vaccinMap = new VaccinMapping();
        }
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
            //vaccin
            if (entity.Vaccin is null)
            {
                result.Vaccin = new Vaccin();
                result.Vaccin.Id = entity.VaccinId;
            }
            else
            {
                result.Vaccin = vaccinMap.Mapping(entity.Vaccin);
            }
            return result;
        }
    }
}
