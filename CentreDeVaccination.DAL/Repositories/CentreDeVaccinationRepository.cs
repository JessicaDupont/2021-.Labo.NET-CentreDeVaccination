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
        public CentreDeVaccinationRepository(DataContext db) : base(db)
        {
        }

        public ICentreDeVaccination Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICentreDeVaccination> Read()
        {
            List<ICentreDeVaccination> result = new List<ICentreDeVaccination>();
            CentreDeVaccinationMapping cvM = new CentreDeVaccinationMapping();
            foreach (CentreVaccinationEntity cv in db.Centres.ToList())
            {
                result.Add(cvM.Mapping(cv));
            }
            return result;
        }

        public IEnumerable<ICentreDeVaccination> Search(IEnumerable<IChamp> filters)
        {
            throw new NotImplementedException();
        }
    }
}
