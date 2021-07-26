using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.Forms;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories.Bases
{
    public interface ILotRepository : 
        IRepositoryCreate<ILot, LotForm, int>
    {
    }
}
