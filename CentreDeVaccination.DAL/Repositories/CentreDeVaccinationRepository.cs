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
using Microsoft.EntityFrameworkCore;

namespace CentreDeVaccination.DAL.Repositories
{
    public class CentreDeVaccinationRepository : RepositoryBase, ICentreDeVaccinationRepository
    {
        private CentreDeVaccinationMapping centreMap;

        public CentreDeVaccinationRepository(DataContext db) : base(db)
        {
            centreMap = new CentreDeVaccinationMapping();
        }

        public ICentreDeVaccination Read(int id)
        {
            return db.Centres
                .Where(x => x.Id == id)
                .Include(x => x.Entrepot)
                    .ThenInclude(x => x.Adresse)
                .Include(x => x.Entrepot)
                    .ThenInclude(x => x.Transits)
                        .ThenInclude(x => x.Lot)
                            .ThenInclude(x => x.Vaccin)
                .Include(x => x.Horaires)
                .Include(x => x.Personnel)
                    .ThenInclude(x => x.Utilisateur)
                    .Select(centreMap.Mapping)
                .First();

            //ICentreDeVaccination result = db.Centres
            //    .Where(x => x.Id == id)
            //    .Select(centreMap.Mapping)
            //    .FirstOrDefault();
            //result.Entrepot = entrepotRepository.Read(result.Entrepot.Id);
            //result.Equipe = personnelRepository.Search("CentreId", result.Id);
            //result.Horaire = horaireRepository.Search("CentreId", result.Id);
            //IDictionary<string, object> filtres = new Dictionary<string, object>();
            //filtres.Add("CentreId", result.Id);
            //filtres.Add("ResponsableCentre", true);
            //result.Responsable = personnelRepository.Search(filtres).First();
            //return result;
        }

        public IEnumerable<ICentreDeVaccination> Read()
        {
            IList<ICentreDeVaccination> result = new List<ICentreDeVaccination>();
            IEnumerable<CentreVaccinationEntity> preResult = db.Centres
                .Include(x => x.Entrepot)
                    .ThenInclude(x => x.Adresse)
                .Include(x => x.Entrepot)
                    .ThenInclude(x => x.Transits)
                        .ThenInclude(x => x.Lot)
                            .ThenInclude(x => x.Vaccin)
                .Include(x => x.Horaires)
                .Include(x => x.Personnel)
                    .ThenInclude(x => x.Utilisateur);

            foreach (CentreVaccinationEntity entity in preResult)
            {
                ICentreDeVaccination model = centreMap.Mapping(entity);

                result.Add(model);
            }

            return result;
        }

    }
}
