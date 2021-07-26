using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Mapping
{
    public class RdvMapping : IMapping<RendezVousEntity, IRendezVous>
    {
        private readonly CentreDeVaccinationMapping centreMap;
        private readonly LotMapping lotMap;
        private readonly EmployeMapping employeMap;
        private readonly VaccinMapping vaccinMap;
        private readonly bool detailsPatient;

        public RdvMapping(bool detailsPatient = true)
        {
            centreMap = new CentreDeVaccinationMapping();
            lotMap = new LotMapping();
            employeMap = new EmployeMapping();
            vaccinMap = new VaccinMapping();
            this.detailsPatient = detailsPatient;
        }
        public RendezVousEntity Mapping(IRendezVous model)
        {
            throw new NotImplementedException();
        }

        public IRendezVous Mapping(RendezVousEntity entity)
        {
            IRendezVous result = new Rdv();
            result.Id = entity.Id;
            result.RendezVous = entity.RendezVous;
            //centre
            if (entity.Centre is null)
            {
                result.Centre = new Centre();
                result.Centre.Id = entity.CentreId;
            }
            else { result.Centre = centreMap.Mapping(entity.Centre); }
            //lot
            if (entity.Lot is null && entity.LotId <= 0) { result.Lot = null; }
            else if (entity.Lot is null)
            {
                result.Lot = new Lot();
                result.Lot.Id = entity.LotId;
            }
            else { result.Lot = lotMap.Mapping(entity.Lot); }
            //patient
            if (!detailsPatient || entity.Patient is null)
            {
                result.Patient = new Patient();
                result.Patient.Id = entity.PatientId;
            }
            else
            {
                PatientMapping patientMap = new PatientMapping();
                result.Patient = patientMap.Mapping(entity.Patient);
            }
            //soignant
            if (entity.Personnel is null && entity.PersonnelId <= 0) { result.Soignant = null; }
            else if (entity.Personnel is null)
            {
                result.Soignant = new Employe();
                result.Soignant.Id = entity.PersonnelId;
            }
            else { result.Soignant = employeMap.Mapping(entity.Personnel); }
            //vaccinchoisi
            if (entity.Vaccin is null)
            {
                result.VaccinChoisi = new Vaccin();
                result.VaccinChoisi.Id = entity.VaccinId;
            }
            else { result.VaccinChoisi = vaccinMap.Mapping(entity.Vaccin); }

            return result;
        }
    }
}
