using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.Forms;
using CentreDeVaccination.Models.IModels;
using Microsoft.EntityFrameworkCore;
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

        public IPatient Read(int id)
        {
            return db.Patients
                .Where(x => x.Id == id)
                .Include(x => x.Adresse)
                .Include(x => x.Utilisateur)
                .Include(x => x.RDVs)
                    .ThenInclude(x => x.Centre)
                        .ThenInclude(x => x.Entrepot)
                            .ThenInclude(x => x.Adresse)
                .Include(x => x.RDVs)
                    .ThenInclude(x => x.Vaccin)
                .Include(x => x.RDVs)
                    .ThenInclude(x => x.Personnel)
                        .ThenInclude(x => x.Utilisateur)
                .Include(x => x.RDVs)
                    .ThenInclude(x => x.Lot)
                        .ThenInclude(x => x.Vaccin)
                .Select(patientMap.Mapping)
                .First();               
        }

        public IEnumerable<IPatient> Read()
        {
            throw new NotImplementedException();
        }
    }
}
