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
    public class EntrepotRepository : RepositoryBase, IEntrepotRepository
    {
        EntrepotMapping map;

        public EntrepotRepository(DataContext db) : base(db)
        {
            map = new EntrepotMapping();
        }

        public IEntrepot Read(int id)
        {
            return db.Entrepots
                .Where(x => x.Id == id)
                .Select(map.Mapping)
                .FirstOrDefault();
        }

        public IEnumerable<IEntrepot> Read()
        {
            return db.Entrepots
                .Where(x => x.IsVisible == true)
                .Select(map.Mapping);
        }
    }
}
