using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.DB.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Mapping
{
    public interface IMapping<TEntity, TModel>
        where TEntity : IEntity
        where TModel : IModel
    {
        public TEntity Mapping(TModel model);
        public TModel Mapping(TEntity entity);
    }
}
