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
        private readonly EntrepotRepository entrepotRepository;
        private readonly PersonnelRepository personnelRepository;
        private readonly HoraireRepository horaireRepository;

        //private EntrepotMapping entrepotMap;
        //private PersonnelMapping personnelMap;
        //private HoraireMapping horaireMap;
        //private SoignantMapping soignantMap;
        //private AdresseMapping adresseMap;
        //private VaccinMapping vaccinMap;

        public CentreDeVaccinationRepository(DataContext db) : base(db)
        {
            centreMap = new CentreDeVaccinationMapping();
            entrepotRepository = new EntrepotRepository(db);
            personnelRepository = new PersonnelRepository(db);
            horaireRepository = new HoraireRepository(db);
            //personnelMap = new PersonnelMapping();
            //horaireMap = new HoraireMapping();
            //soignantMap = new SoignantMapping();
            //adresseMap = new AdresseMapping();
            //vaccinMap = new VaccinMapping();
        }

        public ICentreDeVaccination Read(int id)
        {
            ICentreDeVaccination result = db.Centres
                .Where(x => x.Id == id)
                .Select(centreMap.Mapping)
                .FirstOrDefault();

            result.Entrepot = entrepotRepository.Read(result.Entrepot.Id);
            result.Equipe = personnelRepository.Search("CentreId", result.Id);
            result.Horaire = horaireRepository.Search("CentreId", result.Id);
            IDictionary<string, object> filtres = new Dictionary<string, object>();
            filtres.Add("CentreId", result.Id);
            filtres.Add("ResponsableCentre", true);
            result.Responsable = personnelRepository.Search(filtres).First();

            return result;
        }

        public IEnumerable<ICentreDeVaccination> Read()
        {
            IEnumerable<CentreVaccinationEntity> result;

            result = db.Centres
                .Where(x => x.IsVisible == true);

            return result;
        }

    }
}
