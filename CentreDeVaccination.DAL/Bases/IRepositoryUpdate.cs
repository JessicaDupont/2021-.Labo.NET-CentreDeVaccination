using CentreDeVaccination.Models.Forms.Bases;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepositoryUpdate<TModel, Tid>
        where TModel : IModel
    {
        public TModel Update(Tid id, TModel model);
    }
    public interface IRepositoryUpdate<TModel, TForm, Tid>
        where TModel : IModel
        where TForm : IForm
    {
        public TModel Update(Tid id, TForm form);
    }
}
