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
    public class PersonnelRepository : RepositoryBase, IPersonnelRepository
    {
        private PersonnelMapping map;
        public PersonnelRepository(DataContext db) : base(db)
        {
            map = new PersonnelMapping();
        }

        public IEnumerable<IPersonnel> Search(string champ, bool valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, int valeur)
        {
            if (champ.Equals("CentreId"))
            {
                return db.Personnel
                    .Where(x => x.CentreId == valeur)
                    .Select(map.Mapping);
            }
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, string valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, DateTime valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, TimeSpan valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(IDictionary<string, object> filtres)
        {
            int nbFiltresApplique = 0;
            IEnumerable<PersonnelEntity> preResult = db.Personnel;
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
