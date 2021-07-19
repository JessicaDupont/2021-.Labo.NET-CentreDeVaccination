using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IRepositorySearch<TModel, Tid>
        where TModel : IModel
    {
        public IEnumerable<TModel> Search(string champ, bool valeur);
        public IEnumerable<TModel> Search(string champ, int valeur);
        public IEnumerable<TModel> Search(string champ, string valeur);
        public IEnumerable<TModel> Search(string champ, DateTime valeur);
        public IEnumerable<TModel> Search(string champ, TimeSpan valeur);
        public IEnumerable<TModel> Search(IDictionary<string, object> filtres);
    }
}
