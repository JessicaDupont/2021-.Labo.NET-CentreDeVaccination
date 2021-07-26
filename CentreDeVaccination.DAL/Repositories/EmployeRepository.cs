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
    public class EmployeRepository : RepositoryBase, IEmployeRepository
    {
        private readonly EmployeMapping employeMap;

        public EmployeRepository(DataContext db) : base(db)
        {
            employeMap = new EmployeMapping();
        }

        public IEnumerable<IEmploye> Search(string champ, bool valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEmploye> Search(string champ, int valeur)
        {
            if (champ.Equals("CentreId"))
            {
                return db.Personnel
                    .Where(x => x.CentreId == valeur)
                    .Select(employeMap.Mapping);
            }
            throw new NotImplementedException();
        }

        public IEnumerable<IEmploye> Search(string champ, string valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEmploye> Search(string champ, DateTime valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEmploye> Search(string champ, TimeSpan valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEmploye> Search(IDictionary<string, object> filtres)
        {
            throw new NotImplementedException();
        }
    }
}
