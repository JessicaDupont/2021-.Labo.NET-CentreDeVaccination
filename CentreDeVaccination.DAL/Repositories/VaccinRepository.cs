using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories
{
    public class VaccinRepository : RepositoryBase, IVaccinRepository
    {
        VaccinMapping map;
        public VaccinRepository(DataContext db) : base(db)
        {
            map = new VaccinMapping();
        }

        public IVaccin Read(int id)
        {
            return db.Vaccins
                .Where(x => x.Id == id)
                .Select(map.Mapping)
                .FirstOrDefault();
        }

        public IEnumerable<IVaccin> Read()
        {
            return db.Vaccins
                .Where(x => x.IsVisible == true)
                .Select(map.Mapping);
        }
    }
}
