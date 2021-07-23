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
    public class EmployeMapping : IMapping<PersonnelEntity, IEmploye>
    {
        private readonly PersonneMapping personneMap;
        private readonly bool detailsCentre;

        //private readonly CentreDeVaccinationMapping centreMap;

        public EmployeMapping(bool detailsCentre = true)
        {
            personneMap = new PersonneMapping();
            this.detailsCentre = detailsCentre;
            //centreMap = new CentreDeVaccinationMapping();
        }

        public PersonnelEntity Mapping(IEmploye model)
        {
            throw new NotImplementedException();
        }

        public IEmploye Mapping(PersonnelEntity entity)
        {
            IEmploye result = new Employe();
            result.Id = entity.Id;
            result.Grade = (Grades)Enum.Parse(typeof(Grades), entity.Grade);
            result.Inami = entity.NumInami;
            result.ResponsableCentre = entity.ResponsableCentre;
            //personne
            if (entity.Utilisateur is null)
            {
                result.Personne = new Personne();
                result.Personne.Id = entity.UtilisateurId;
            }
            else
            {
                result.Personne = personneMap.Mapping(entity.Utilisateur);
            }
            //centre
            if(entity.Centre is null  || !detailsCentre)
            {
                result.Centre = new Centre();
                result.Centre.Id = entity.CentreId;
                //result.Centre.Responsable = result;
            }
            else
            {
                CentreDeVaccinationMapping centreMap = new CentreDeVaccinationMapping();
                result.Centre = centreMap.Mapping(entity.Centre);
            }
            return result;
        }
    }
}
