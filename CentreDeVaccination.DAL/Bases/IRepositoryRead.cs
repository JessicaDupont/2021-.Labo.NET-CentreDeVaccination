using CentreDeVaccination.DAL.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepositoryRead<TModel, Tid>
        where TModel : IModel
    {
        public TModel Read(Tid id);
        public IEnumerable<TModel> Read();
    }
}
