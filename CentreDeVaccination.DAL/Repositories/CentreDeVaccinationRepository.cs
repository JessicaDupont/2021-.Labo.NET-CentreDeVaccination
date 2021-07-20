using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.Models;

namespace CentreDeVaccination.DAL.Repositories
{
    public class CentreDeVaccinationRepository : RepositoryBase, ICentreDeVaccinationRepository
    {
        private CentreDeVaccinationMapping centreMap;
        private EntrepotMapping entrepotMap;
        private PersonnelMapping personnelMap;
        private HoraireMapping horaireMap;
        private SoignantMapping soignantMap;
        private AdresseMapping adresseMap;
        private VaccinMapping vaccinMap;

        public CentreDeVaccinationRepository(DataContext db) : base(db)
        {
            centreMap = new CentreDeVaccinationMapping();
            entrepotMap = new EntrepotMapping();
            personnelMap = new PersonnelMapping();
            horaireMap = new HoraireMapping();
            soignantMap = new SoignantMapping();
            adresseMap = new AdresseMapping();
            vaccinMap = new VaccinMapping();
        }

        public ICentreDeVaccination Read(int id)
        {
            ICentreDeVaccination result = db.Centres
                .Where(x => x.Id == id)
                .Select(centreMap.Mapping)
                .FirstOrDefault();
            //responsable
            PersonnelRepository perR = new PersonnelRepository(db);
            IDictionary<string, object> filtres = new Dictionary<string, object>();
            filtres.Add("ResponsableCentre", true);
            filtres.Add("CentreId", result.Id);
            result.Responsable = perR.Search(filtres).First();
            //result.Responsable = db.Personnel
            //    .Where(x => x.ResponsableCentre == true)
            //    .Where(x => x.CentreId == result.Id)
            //    .Select(soignantMap.Mapping)
            //    .FirstOrDefault();
            //entrepot
            EntrepotRepository entR = new EntrepotRepository(db);
            result.Entrepot = entR.Read(result.Entrepot.Id);
            //result.Entrepot = db.Entrepots
            //        .Where(x => x.Id == result.Entrepot.Id)
            //        .Select(entrepotMap.Mapping)
            //        .FirstOrDefault();
            ////entrepot.adresse
            //result.Entrepot.Adresse = db.Adresses
            //    .Where(x => x.Id == result.Entrepot.Adresse.Id)
            //    .Select(adresseMap.Mapping)
            //    .FirstOrDefault();
            ////entrepot.vaccins
            //result.Entrepot.Vaccins = db.Transits
            //    .Where(x => x.IsVisible == true)
            //    .Where(x => x.EntrepotId == result.Entrepot.Id)
            //    .Join(
            //        db.Lots,
            //        t => t.LotId,
            //        l => l.Id,
            //        (t, l) => new
            //        {
            //            VaccinId = l.VaccinId,
            //            IsVisible = l.IsVisible
            //        }
            //    )
            //    .Where(x => x.IsVisible == true)
            //    .Join(
            //        db.Vaccins,
            //        j => j.VaccinId,
            //        v => v.Id,
            //        (j, v) => new VaccinEntity
            //        {
            //            Id = v.Id,
            //            Fabricant = v.Fabricant,
            //            Nom = v.Nom,
            //            NbJoursIntervalleMinimum = v.NbJoursIntervalleMinimum,
            //            NbJoursIntervalleMaximum = v.NbJoursIntervalleMaximum,
            //            IsVisible = v.IsVisible
            //        }
            //    )
            //    .Select(vaccinMap.Mapping);
            //equipe
            result.Equipe = perR.Search("CentreId", result.Id);
            //result.Equipe = db.Personnel
            //    .Where(x => x.CentreId == result.Id)
            //    .Select(personnelMap.Mapping);
            //horaire
            HoraireRepository horaireR = new HoraireRepository(db);
            result.Horaire = horaireR.Search("CentreId", result.Id);
            //result.Horaire = db.Horaires
            //    .Where(x => x.CentreId == result.Id)
            //    .Select(horaireMap.Mapping);
            return result;
        }

        public IEnumerable<ICentreDeVaccination> Read()
        {
            IEnumerable<ICentreDeVaccination> result = db.Centres
                .Where(x => x.IsVisible == true)
                .Select(centreMap.Mapping);

            //IList<ICentreDeVaccination> result = db.Centres
            //    .Where(x => x.IsVisible == true)
            //    .Select(centreMap.Mapping)
            //    .ToList();
            //for(int i=0; i < result.Count(); i++)
            //{
            //    result[i].Entrepot = db.Entrepots
            //        .Where(x => x.Id == result[i].Entrepot.Id)
            //        .Select(entrepotMap.Mapping)
            //        .FirstOrDefault();
            //    result[i].Entrepot.Adresse = db.Adresses
            //        .Where(x => x.Id == result[i].Entrepot.Adresse.Id)
            //        .Select(adresseMap.Mapping)
            //        .FirstOrDefault();
            //    result[i].Entrepot.Vaccins = db.Transits
            //        .Where(x => x.IsVisible == true)
            //        .Where(x => x.EntrepotId == result[i].Entrepot.Id)
            //        .Join(
            //            db.Lots,
            //            t => t.LotId,
            //            l => l.Id,
            //            (t, l) => new
            //            {
            //                VaccinId = l.VaccinId,
            //                IsVisible = l.IsVisible
            //            }
            //        )
            //        .Where(x => x.IsVisible == true)
            //        .Join(
            //            db.Vaccins,
            //            j => j.VaccinId,
            //            v => v.Id,
            //            (j, v) => new VaccinEntity
            //            {
            //                Id = v.Id,
            //                Fabricant = v.Fabricant,
            //                Nom = v.Nom,
            //                NbJoursIntervalleMinimum = v.NbJoursIntervalleMinimum,
            //                NbJoursIntervalleMaximum = v.NbJoursIntervalleMaximum,
            //                IsVisible = v.IsVisible
            //            }
            //        )
            //        .Select(vaccinMap.Mapping);
            //    result[i].Equipe = db.Personnel
            //        .Where(x => x.CentreId == result[i].Id)
            //        .Select(personnelMap.Mapping);
            //    result[i].Horaire = db.Horaires
            //        .Where(x => x.CentreId == result[i].Id)
            //        .Select(horaireMap.Mapping);
            //    result[i].Responsable = db.Personnel
            //        .Where(x => x.ResponsableCentre == true)
            //        .Where(x => x.CentreId == result[i].Id)
            //        .Select(soignantMap.Mapping)
            //        .FirstOrDefault();
            //}
            return result;
        }

    }
}
