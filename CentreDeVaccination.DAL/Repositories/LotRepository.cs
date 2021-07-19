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
    public class LotRepository : RepositoryBase, ILotRepository
    {
        public LotMapping map;
        public LotRepository(DataContext db) : base(db)
        {
            map = new LotMapping();
        }

        public ILot Read(int id)
        {
            return db.Lots
                .Where(x => x.Id == id)
                .Select(map.Mapping)
                .FirstOrDefault();
        }

        public IEnumerable<ILot> Read()
        {
            return db.Lots
                .Where(x => x.IsVisible == true)
                .Select(map.Mapping);
        }
    }
}
