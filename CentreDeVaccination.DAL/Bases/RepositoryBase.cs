using CentreDeVaccination.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public abstract class RepositoryBase
    {
        protected readonly DataContext db;

        public RepositoryBase(DataContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
    }
}
