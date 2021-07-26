using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.Forms;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Mapping
{
    public class TransitMapping : IMapping<TransitEntity, IEntrepot, TransitForm>
    {
        public TransitEntity Mapping(TransitForm form)
        {
            TransitEntity result = new TransitEntity();
            result.Id = form.Id;
            result.DateEntree = form.DateEntree;
            result.DateSortie = form.DateSortie;
            result.EntrepotId = form.EntrepotId;
            result.LotId = form.LotId;
            return result;
        }

        public IEntrepot Mapping(TransitEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
