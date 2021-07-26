using CentreDeVaccination.Models.Forms.Bases;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepositoryCreate<TModel, Tid>
        where TModel : IModel
    {
        public TModel Create(TModel model);
    }
    public interface IRepositoryCreate<TModel, TForm, Tid>
        where TModel : IModel
        where TForm : IForm
    {
        public TModel Create(TForm form);
    }
}
