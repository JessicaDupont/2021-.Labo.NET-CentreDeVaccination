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
    public class LotRepository : RepositoryBase, ILotRepository
    {
        private readonly LotMapping lotMap;

        public LotRepository(DataContext db) : base(db)
        {
            lotMap = new LotMapping();
        }

        public ILot Create(LotForm form)
        {
            LotEntity entity = lotMap.Mapping(form);
            EntityEntry<LotEntity> result = db.Lots.Add(entity);
            db.SaveChanges();
            entity = db.Lots
                .Where(x => x.NumLot == form.NumLot)
                .FirstOrDefault();

            //ajouter 1er transit
            TransitEntity transit = new TransitEntity();
            transit.EntrepotId = form.EntrepotId;
            transit.DateEntree = form.DateEntree;
            transit.LotId = entity.Id;
            db.Transits.Add(transit);
            db.SaveChanges();


            return lotMap.Mapping(entity);
        }
    }
}
