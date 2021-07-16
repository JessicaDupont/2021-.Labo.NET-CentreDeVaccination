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
    public class HoraireRepository : RepositoryBase, IHoraireRepository
    {
        private HoraireMapping map = new HoraireMapping();
        public HoraireRepository(DataContext db) : base(db)
        {
        }

        public IEnumerable<IHoraire> Search(IDictionary<string, int> filtres)
        {
            return db.Horaires
                .Where(x => x.CentreId == filtres[nameof(x.CentreId)])
                .Select(map.Mapping);            
        }

    }
}
