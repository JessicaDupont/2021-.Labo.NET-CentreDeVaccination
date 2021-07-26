using CentreDeVaccination.Models.Forms.Bases;
using CentreDeVaccination.Models.IModels;
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
        where TModel : IModel
    {
    }
    public interface IRepository<TModel, TForm, Tid> :
        IRepositoryCreate<TModel, TForm, Tid>,
        IRepositoryRead<TModel, Tid>,
        IRepositoryUpdate<TModel, TForm, Tid>,
        IRepositoryDelete<TModel, Tid>,
        IRepositorySearch<TModel, Tid>
        where TModel : IModel
        where TForm : IForm
    {
    }
}
