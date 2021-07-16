using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
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
        public EntrepotRepository(DataContext db) : base(db)
        {
        }

        public IEntrepot Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntrepot> Read()
        {
            List<IEntrepot> result = new List<IEntrepot>();

            EntrepotMapping map = new EntrepotMapping();
            foreach (EntrepotEntity entity in db.Entrepots)
            {
                result.Add(map.Mapping(entity));
            }

            return result;
        }
    }
}
