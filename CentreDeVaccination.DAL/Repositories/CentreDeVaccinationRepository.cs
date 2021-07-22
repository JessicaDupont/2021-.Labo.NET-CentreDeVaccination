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
                Centre model = new Centre();

                model.Id = entity.Id;
                model.Entrepot = new Entrepot
                {
                    Id = entity.Entrepot.Id,
                    Nom = entity.Entrepot.Nom,
                    Adresse = new Adresse
                    {
                        Id = entity.Entrepot.Adresse.Id,
                        Rue = entity.Entrepot.Adresse.Rue,
                        Numero = entity.Entrepot.Adresse.Numero,
                        CodePostal = entity.Entrepot.Adresse.CodePostal,
                        Ville = entity.Entrepot.Adresse.Ville
                    },
                    //Vaccins = new List<IVaccin>()
                };

                //pour chaque transit, j'ajoute le vaccin
                IList<IVaccin> vaccins = new List<IVaccin>();
                foreach (TransitEntity te in entity.Entrepot.Transits)
                {
                    IVaccin v = new Vaccin
                    {
                        Id = te.Lot.Vaccin.Id,
                        Fabricant = te.Lot.Vaccin.Fabricant,
                        Nom = te.Lot.Vaccin.Nom,
                        IntervalleMin = new TimeSpan(te.Lot.Vaccin.NbJoursIntervalleMinimum, 0, 0, 0),
                        IntervalleMax = new TimeSpan(te.Lot.Vaccin.NbJoursIntervalleMaximum, 0, 0, 0)
                    };
                    if (!vaccins.Contains(v)) { vaccins.Add(v); }//éviter les doublons
                }
                model.Entrepot.Vaccins = vaccins;

                //pour chaque personnel, ajouter a l'équipe, + responsable
                IList<IPersonnel> equipe = new List<IPersonnel>();
                foreach (PersonnelEntity pe in entity.Personnel)
                {
                    ISoignant p = new Soignant();
                    p.Id = pe.Id;
                    p.Nom = pe.Utilisateur.Nom;
                    p.Prenom = pe.Utilisateur.Prenom;
                    p.Email = pe.Utilisateur.Email;
                    p.Grade = (Grades)Enum.Parse(typeof(Grades), pe.Grade);
                    p.Inami = pe.NumInami;
                    p.ResponsableCentre = pe.ResponsableCentre;
                    if (pe.ResponsableCentre) { model.Responsable = p; }
                    equipe.Add(p);
                }
                model.Equipe = equipe;

                //horaires
                IList<IHoraire> horaires = new List<IHoraire>();
                foreach(HoraireEntity he in entity.Horaires)
                {
                    IHoraire h = new Horaire();
                    h.Id = he.Id;
                    h.DureePlageVaccination = he.DureePlageVaccination;
                    h.Fermeture = he.Fermeture;
                    h.FermetureBis = he.FermetureBis;
                    h.Jour = he.Jour;
                    h.NbVaccinationParPlage = he.NbVaccinationParPlage;
                    h.Ouverture = he.Ouverture;
                    h.OuvertureBis = he.OuvertureBis;
                    horaires.Add(h);
                }
                model.Horaire = horaires;

                result.Add(model);
            }//fin foreach preresult

            return result;
        }

    }
}
