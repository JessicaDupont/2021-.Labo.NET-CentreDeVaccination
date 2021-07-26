using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.DB.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentreDeVaccination.Models.Forms.Bases;

namespace CentreDeVaccination.DAL.Mapping.Bases
{
    public interface IMapping<TEntity, TModel>
        where TEntity : IEntity
        where TModel : IModel
    {
        public TEntity Mapping(TModel model);
        public TModel Mapping(TEntity entity);
    }
    public interface IMapping<TEntity, TModel, TForm>
        where TEntity : IEntity
        where TModel : IModel
        where TForm : IForm
    {
        public TEntity Mapping(TForm form);
        //public TEntity Mapping(TModel model);
        public TModel Mapping(TEntity entity);
    }
}
