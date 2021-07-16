using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentreDeVaccination.DAL.Mapping;

namespace CentreDeVaccination.DAL.Repositories
{
    public class CentreDeVaccinationRepository : RepositoryBase, ICentreDeVaccinationRepository
    {
        private EntrepotRepository entrepotR;
        private CentreDeVaccinationMapping map;

        public CentreDeVaccinationRepository(DataContext db) : base(db)
        {
            map = new CentreDeVaccinationMapping();
            entrepotR = new EntrepotRepository(db);
        }

        public ICentreDeVaccination Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICentreDeVaccination> Read()
        {
            return db.Centres.Select(map.Mapping);
        }

    }
}
