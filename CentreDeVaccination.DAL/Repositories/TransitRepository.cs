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
    public class TransitRepository : RepositoryBase, ITransitRepository
    {
        TransitMapping map;
        public TransitRepository(DataContext db) : base(db)
        {
            map = new TransitMapping();
        }

        public IEnumerable<ITransit> Search(string champ, bool valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransit> Search(string champ, int valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransit> Search(string champ, string valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransit> Search(string champ, DateTime valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransit> Search(string champ, TimeSpan valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransit> Search(IDictionary<string, object> filtres)
        {
            int nbFiltresApplique = 0;
            IEnumerable<TransitEntity> preResult = db.Transits;
            foreach (KeyValuePair<string, object> f in filtres)
            {
                if (f.Key.Equals("EntrepotId"))
                {
                    preResult = preResult.Where(x => x.EntrepotId == (int)f.Value);
                    nbFiltresApplique++;
                }
                else if (f.Key.Equals("DateSortie"))
                {
                    preResult = preResult.Where(x => x.DateSortie.Equals(f.Value));
                    nbFiltresApplique++;
                }
            }
            if (nbFiltresApplique < filtres.Count) { throw new NotImplementedException(); }
            return preResult.Select(map.Mapping);
        }
    }
}
