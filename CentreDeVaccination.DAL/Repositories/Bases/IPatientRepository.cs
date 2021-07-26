using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.Models.Forms;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories.Bases
{
    public interface IPatientRepository :
        IRepositoryCreate<IPatient, PatientForm, int>,
        IRepositoryRead<IPatient, int>
    {
    }
}
