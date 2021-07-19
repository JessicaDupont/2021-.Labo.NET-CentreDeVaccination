using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
using System;

namespace CentreDeVaccination.DAL.Mapping
{
    public class PersonnelMapping : IMapping<PersonnelEntity, IPersonnel>
    {
        public PersonnelEntity Mapping(IPersonnel model)
        {
            throw new System.NotImplementedException();
        }

        public IPersonnel Mapping(PersonnelEntity entity)
        {
            if (!(entity.NumInami is null))
            {
                ISoignant result = new Soignant();
                result.Id = entity.Id;
                result.Grade = (Grades)Enum.Parse(typeof(Grades), entity.Grade);
                result.Inami = entity.NumInami;
                return result;
            }
            else 
            { 
                IPersonnel result = new Personnel();
                result.Id = entity.Id;
                result.Grade = (Grades)Enum.Parse(typeof(Grades), entity.Grade);
                return result;
            }            
        }
    }
}