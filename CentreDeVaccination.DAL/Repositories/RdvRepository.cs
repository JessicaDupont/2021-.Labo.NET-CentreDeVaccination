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

        public IRendezVous Injection(InjectionForm form)
        {
            RendezVousEntity entity = db.RDVs
                .Where(x => x.Id == form.RdvId)
                .FirstOrDefault();
            entity.LotId = form.LotId;
            entity.PersonnelId = form.SoignantId;
            EntityEntry<RendezVousEntity> result = db.Update(entity);

            //diminuer nb doses restantes
            LotEntity lotE = db.Lots
                .Where(x => x.Id == form.LotId)
                .FirstOrDefault();
            lotE.NbDosesRestantes--;
            db.Update(lotE);

            db.SaveChanges();

            return rdvMap.Mapping(result.Entity);
        }
    }
}
