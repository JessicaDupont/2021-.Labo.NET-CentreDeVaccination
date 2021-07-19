using CentreDeVaccination.DAL.Repositories.bases;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.Models.IModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentreDeVaccination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentreVaccinationController : ControllerBase
    {
        private readonly ICentreDeVaccinationRepository repository;
        private readonly IEntrepotRepository entrepotRepository;
        private readonly IHoraireRepository horaireRepository;
        private readonly IPersonnelRepository personnelRepository;
        private readonly ISoignantRepository soignantRepository;
        private readonly IAdresseRepository adresseRepository;
        private readonly ITransitRepository transitRepository;
        private readonly ILotRepository lotRepository;
        private readonly IVaccinRepository vaccinRepository;

        public CentreVaccinationController(
            ICentreDeVaccinationRepository repository, 
            IPersonnelRepository personnelRepository,
            ISoignantRepository soignantRepository,
            IHoraireRepository horaireRepository,
            IEntrepotRepository entrepotRepository,
            IAdresseRepository adresseRepository,
            ITransitRepository transitRepository,
            ILotRepository lotRepository,
            IVaccinRepository vaccinRepository)
        {
            this.repository = repository;
            this.entrepotRepository = entrepotRepository;
            this.horaireRepository = horaireRepository;
            this.personnelRepository = personnelRepository;
            this.soignantRepository = soignantRepository;
            this.adresseRepository = adresseRepository;
            this.transitRepository = transitRepository;
            this.lotRepository = lotRepository;
            this.vaccinRepository = vaccinRepository;
        }

        // GET: api/<CentreVaccinationController>
        /// <summary>
        /// obtenir l'ensemble des centres de vaccination
        /// </summary>
        /// <returns>ensemble des centres</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ICentreDeVaccination>> Get()
        {
            try
            {
                IList<ICentreDeVaccination> result = new List<ICentreDeVaccination>(repository.Read());
                for(int i=0; i<result.Count(); i++)
                {
                    result[i] = InfosCentre(result[i]);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { 
                        Method = "Get",
                        Message = ex.Message
                    });
            }
        }

        /// <summary>
        /// obtenir les détails d'un centre
        /// </summary>
        /// <param name="id">id d'un centre</param>
        /// <returns>infos d'un centre</returns>
        // GET api/<CentreVaccinationController>/5
        [HttpGet("{id}")]
        public ActionResult<ICentreDeVaccination> Get(int id)
        {
            try
            {
                ICentreDeVaccination result = repository.Read(id);
                result = InfosCentre(result);
                return result is null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Method = "Get",
                        Message = ex.Message
                    });
            }
        }

        //// POST api/<CentreVaccinationController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CentreVaccinationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CentreVaccinationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        private ICentreDeVaccination InfosCentre(ICentreDeVaccination centre)
        {
            if (centre is null) { throw new Exception("Centre est null"); }
            if (centre.Id <= 0) { throw new Exception("Centre.Id invalide"); }

            centre.Entrepot = ObtenirEntrepot(centre.Entrepot.Id);
            centre.Responsable = ObtenirResponsable(centre.Id);
            centre.Equipe = ObtenirEquipe(centre.Id);
            centre.Horaire = ObtenirHoraires(centre.Id);

            return centre;

        }

        private IEnumerable<IHoraire> ObtenirHoraires(int id)
        {
            return horaireRepository.Search("CentreId", id);
        }

        private IEnumerable<IPersonnel> ObtenirEquipe(int id)
        {
            return personnelRepository.Search("CentreId", id);
        }

        private ISoignant ObtenirResponsable(int id)
        {
            IDictionary<string, object> filtres = new Dictionary<string, object>();
            filtres.Add("ResponsableCentre", true);
            filtres.Add("CentreId", id);
            return soignantRepository.Search(filtres).First();
        }

        private IEntrepot ObtenirEntrepot(int id)
        {
            IEntrepot entrepot = entrepotRepository.Read(id);
            entrepot.Adresse = adresseRepository.Read(entrepot.Adresse.Id);
            entrepot.Vaccins = ObtenirVaccins(entrepot.Id);
            return entrepot;
        }

        private IEnumerable<IVaccin> ObtenirVaccins(int entrepotId)
        {
            IEnumerable<ITransit> transits = ObtenirTransits(entrepotId);
            IEnumerable<ILot> lots = ObtenirLots(transits);

            IList<IVaccin> result = new List<IVaccin>();
            foreach (ILot l in lots)
            {
                result.Add(vaccinRepository.Read(l.Vaccin.Id));
            }

            return result.Distinct();
        }

        private IEnumerable<ILot> ObtenirLots(IEnumerable<ITransit> transits)
        {
            IList<ILot> result = new List<ILot>();
            foreach (ITransit t in transits)
            {
                result.Add(lotRepository.Read(t.Lot.Id));
            }
            return result;
        }

        private IEnumerable<ITransit> ObtenirTransits(int entrepotId)
        {
            IDictionary<string, object> filtres;
            filtres = new Dictionary<string, object>();
            filtres.Add("EntrepotId", entrepotId);
            filtres.Add("DateSortie", null);
            return transitRepository.Search(filtres);
        }

    }
}
