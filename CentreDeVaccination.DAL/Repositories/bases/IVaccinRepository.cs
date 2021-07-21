using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories.bases
{
    public interface IVaccinRepository : 
        IRepositoryRead<IVaccin, int>,
        IRepositorySearch<IVaccin, int>
    {
    }
}
