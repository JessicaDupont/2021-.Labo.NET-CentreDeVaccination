using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories
{
    public class VaccinRepository : RepositoryBase, IVaccinRepository
    {
        VaccinMapping map;
        public VaccinRepository(DataContext db) : base(db)
        {
            map = new VaccinMapping();
        }

        public IVaccin Read(int id)
        {
            return db.Vaccins
                .Where(x => x.Id == id)
                .Select(map.Mapping)
                .FirstOrDefault();
        }

        public IEnumerable<IVaccin> Read()
        {
            return db.Vaccins
                .Where(x => x.IsVisible == true)
                .Select(map.Mapping);
        }

        public IEnumerable<IVaccin> Search(string champ, bool valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVaccin> Search(string champ, int valeur)
        {
            if(champ.Equals("EntrepotId"))
            {
                return db.Transits
                    .Where(x => x.IsVisible == true)
                    .Where(x => x.EntrepotId == valeur)
                    .Join(
                        db.Lots,
                        e => e.LotId,
                        l => l.Id,
                        (e, l) => new
                        {
                            IsVisible = l.IsVisible,
                            VaccinId = l.VaccinId
                        }
                    )
                    .Where(x => x.IsVisible == true)
                    .Join(
                        db.Vaccins,
                        j => j.VaccinId,
                        v => v.Id,
                        (j, v) => new VaccinEntity
                        {
                            Id = v.Id,
                            Fabricant = v.Fabricant,
                            Nom = v.Nom,
                            NbJoursIntervalleMinimum = v.NbJoursIntervalleMinimum,
                            NbJoursIntervalleMaximum = v.NbJoursIntervalleMaximum,
                            IsVisible = v.IsVisible
                        }
                    )
                    .Where(x => x.IsVisible == true)
                    .Select(map.Mapping);
            }
            throw new NotImplementedException();
        }

        public IEnumerable<IVaccin> Search(string champ, string valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVaccin> Search(string champ, DateTime valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVaccin> Search(string champ, TimeSpan valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVaccin> Search(IDictionary<string, object> filtres)
        {
            throw new NotImplementedException();
        }
    }
}
