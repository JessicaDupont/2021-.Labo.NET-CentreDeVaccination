using CentreDeVaccination.Models.Forms.Bases;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepositoryUser<TModel, TForm>
        where TModel : IModel
        where TForm : IForm
    {
        public TModel Check(TForm form);
    }
}
