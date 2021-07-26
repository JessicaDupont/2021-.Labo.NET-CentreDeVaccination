using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.Forms;
using CentreDeVaccination.Models.IModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories
{
    public class PatientRepository : RepositoryBase, IPatientRepository
    {
        private readonly PatientMapping patientMap;

        public PatientRepository(DataContext db) : base(db)
        {
            patientMap = new PatientMapping();
        }

        public IPatient Create(PatientForm form)
        {
            PatientEntity entity = patientMap.Mapping(form);
            EntityEntry<PatientEntity> result = db.Patients.Add(entity);
            db.SaveChanges();
            return patientMap.Mapping(result.Entity);
        }
    }
}
