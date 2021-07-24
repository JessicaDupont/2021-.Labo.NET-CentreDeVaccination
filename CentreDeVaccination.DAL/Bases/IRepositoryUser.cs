using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepositoryUser<TModel, TSecret, TLogin, TMdp>
        where TModel : IModel
    {
        public TModel Check(TLogin login, TMdp mdp);
        public TModel Create(TSecret model);
    }
}
