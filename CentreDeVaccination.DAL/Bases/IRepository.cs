using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepository<TModel, Tid> :
        IRepositoryCreate<TModel, Tid>, 
        IRepositoryRead<TModel, Tid>, 
        IRepositoryUpdate<TModel, Tid>, 
        IRepositoryDelete<TModel, Tid>, 
        IRepositorySearch<TModel, Tid>
    {
    }
}
