using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories
{
    public class AdresseRepository : RepositoryBase, IAdresseRepository
    {
        AdresseMapping map;
        public AdresseRepository(DataContext db) : base(db)
        {
            map = new AdresseMapping();
        }

        public IAdresse Read(int id)
        {
            return db.Adresses
                .Where(x => x.Id == id)
                .Select(map.Mapping)
                .FirstOrDefault();
        }

        public IEnumerable<IAdresse> Read()
        {
            return db.Adresses
                .Where(x => x.IsVisible == true)
                .Select(map.Mapping);
        }
    }
}
