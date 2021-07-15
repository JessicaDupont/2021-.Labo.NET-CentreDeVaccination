using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
using System;

namespace CentreDeVaccination.DAL.Mapping
{
    public class ResponsableMapping : IMapping<PersonnelEntity, IResponsable>
    {
        public PersonnelEntity Mapping(IResponsable model)
        {
            throw new System.NotImplementedException();
        }

        public IResponsable Mapping(PersonnelEntity entity)
        {
            IResponsable result = new Responsable();

            result.Id = entity.Id;
            result.NumInami = entity.NumInami;
            result.Grade = (Grades) Enum.Parse(typeof(Grades), entity.Grade);
            return result;
        }
    }
}