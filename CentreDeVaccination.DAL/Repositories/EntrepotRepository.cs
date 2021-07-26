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
    public class EntrepotRepository : RepositoryBase, IEntrepotRepository
    {
        private readonly TransitMapping transitMap;
        private readonly EntrepotMapping entrepotMap;

        public EntrepotRepository(DataContext db) : base(db)
        {
            transitMap = new TransitMapping();
            entrepotMap = new EntrepotMapping();
        }

        public IEntrepot Create(TransitForm form)
        {
            TransitEntity entity = transitMap.Mapping(form);
            EntityEntry<TransitEntity> result = db.Transits.Add(entity);
            db.SaveChanges();

            return db.Entrepots
                .Where(x => x.Id == form.EntrepotId)
                .Select(entrepotMap.Mapping)
                .FirstOrDefault(); ;
        }
    }
}
