using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories
{
    public class HoraireRepository : RepositoryBase, IHoraireRepository
    {
        private HoraireMapping map = new HoraireMapping();
        public HoraireRepository(DataContext db) : base(db)
        {
        }

        public IEnumerable<IHoraire> Search(string champ, bool valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHoraire> Search(string champ, int valeur)
        {
            if (champ.Equals("CentreId"))
            {
                return db.Horaires
                    .Where(x => x.IsVisible == true)
                    .Where(x => x.CentreId == valeur)
                    .Select(map.Mapping);
            }
            throw new NotImplementedException();
        }

        public IEnumerable<IHoraire> Search(string champ, string valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHoraire> Search(string champ, DateTime valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHoraire> Search(string champ, TimeSpan valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHoraire> Search(IDictionary<string, object> filtres)
        {
            throw new NotImplementedException();
        }
    }
}
