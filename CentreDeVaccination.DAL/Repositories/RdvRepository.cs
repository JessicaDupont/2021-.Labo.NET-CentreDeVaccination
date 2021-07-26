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
    public class RdvRepository : RepositoryBase, IRdvRepository
    {
        private readonly RdvMapping rdvMap;

        public RdvRepository(DataContext db) : base(db)
        {
            rdvMap = new RdvMapping();
        }

        public IRendezVous Create(RdvForm form)
        {
            RendezVousEntity entity = rdvMap.Mapping(form);
            EntityEntry<RendezVousEntity> result = db.RDVs.Add(entity);
            db.SaveChanges();
            return rdvMap.Mapping(result.Entity);
        }
    }
}
