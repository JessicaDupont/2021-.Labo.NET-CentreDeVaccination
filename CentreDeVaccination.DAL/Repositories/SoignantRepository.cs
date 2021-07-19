using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.bases;
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
    public class SoignantRepository : RepositoryBase, ISoignantRepository
    {
        SoignantMapping map;
        public SoignantRepository(DataContext db) : base(db)
        {
            map = new SoignantMapping();
        }

        public IEnumerable<ISoignant> Search(string champ, bool valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISoignant> Search(string champ, int valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISoignant> Search(string champ, string valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISoignant> Search(string champ, DateTime valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISoignant> Search(string champ, TimeSpan valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISoignant> Search(IDictionary<string, object> filtres)
        {
            int nbFiltresApplique = 0;
            IEnumerable<PersonnelEntity> preResult = db.Personnel.Where(x => x.IsVisible == true) ;
            foreach (KeyValuePair<string, object> f in filtres)
            {
                if (f.Key.Equals("ResponsableCentre"))
                {
                    preResult = preResult.Where(x => x.ResponsableCentre == (bool)f.Value);
                    nbFiltresApplique++;
                }
                else if (f.Key.Equals("CentreId"))
                {
                    preResult = preResult.Where(x => x.CentreId == (int)f.Value);
                    nbFiltresApplique++;
                }
                else if (f.Key.Equals("Grade"))
                {
                    preResult = preResult.Where(x => x.Grade.Equals(f.Value));
                    nbFiltresApplique++;
                }
            }
            if (nbFiltresApplique < filtres.Count) { throw new NotImplementedException(); }
            return preResult.Select(map.Mapping);

        }
    }
}
