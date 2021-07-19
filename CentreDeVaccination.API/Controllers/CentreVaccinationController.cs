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
        private readonly IAdresseRepository adresseRepository;
        private readonly ITransitRepository transitRepository;
        private readonly ILotRepository lotRepository;
        private readonly IVaccinRepository vaccinRepository;

        public CentreVaccinationController(
            ICentreDeVaccinationRepository repository, 
            IPersonnelRepository personnelRepository,
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
                IEnumerable<ICentreDeVaccination> result = repository.Read();
                foreach (ICentreDeVaccination c in result)
                {
                    //responsable
                    IDictionary<string, object> filtres = new Dictionary<string, object>();
                    filtres.Add("ResponsableCentre", true);
                    filtres.Add("CentreId", c.Id);
                    c.Responsable = (ISoignant)personnelRepository.Search(filtres);
                    //equipe
                    c.Equipe = personnelRepository.Search("CentreId", c.Id);
                    //horaire
                    c.Horaire = horaireRepository.Search("CentreId", c.Id);
                    //entrepot
                    c.Entrepot = ObtenirInfosEntrepot(c.Entrepot.Id);                    
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

        private IEntrepot ObtenirInfosEntrepot(int id)
        {
            IEntrepot e = entrepotRepository.Read(id);
            e.Adresse = adresseRepository.Read(e.Adresse.Id);
            e.Vaccins = ObtenirVaccins(id);
            return e;
        }

        private IEnumerable<IVaccin> ObtenirVaccins(int entrepotId)
        {
            IDictionary<string, object> filtres;

            //obtenir tout les transit de l'entrepot dont la date de sortie est toujorus à null
            filtres = new Dictionary<string, object>();
            filtres.Add("EntrepotId", entrepotId);
            filtres.Add("DateSortie", null);
            IEnumerable<ITransit> resultTransit = transitRepository.Search(filtres);

            //obtenir tout les vaccinId des lots obtenus via les transits
            IList<ILot> resultLot = new List<ILot>();
            foreach (ITransit t in resultTransit)
            {
                //pour chaque transit, on obient 1 lot
                resultLot.Add(lotRepository.Read(t.Lot.Id));
            }

            //obtenir tout les vaccins (sans doublon)
            IList<IVaccin> result = new List<IVaccin>();
            foreach (ILot l in resultLot)
            {
                result.Add(vaccinRepository.Read(l.Vaccin.Id));
            }

            return result.Distinct();
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
    }
}
