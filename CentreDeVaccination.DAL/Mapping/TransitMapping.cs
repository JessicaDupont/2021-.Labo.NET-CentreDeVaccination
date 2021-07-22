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
    public class TransitMapping : IMapping<TransitEntity, ITransit>
    {
        public TransitEntity Mapping(ITransit model)
        {
            throw new NotImplementedException();
        }

        public ITransit Mapping(TransitEntity entity)
        {
            ITransit result = new Transit();
            result.Id = entity.Id;
            result.Entrepot = new Entrepot();
            result.Entrepot.Id = entity.EntrepotId;
            result.Lot = new Lot();
            result.Lot.Id = entity.LotId;
            result.DateEntree = entity.DateEntree;
            result.DateSortie = entity.DateSortie;
            return result;
        }
    }
}
