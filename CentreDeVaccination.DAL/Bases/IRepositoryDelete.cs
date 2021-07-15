using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepositoryDelete<TModel, Tid>
        where TModel : IModel
    {
        public TModel Delete(TModel model);
        public TModel Delete(Tid id);
    }
}
