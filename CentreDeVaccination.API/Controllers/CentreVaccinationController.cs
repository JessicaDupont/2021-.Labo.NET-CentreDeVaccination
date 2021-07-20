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

        public CentreVaccinationController(
            ICentreDeVaccinationRepository repository)
        {
            this.repository = repository;
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
                return Ok(repository.Read());
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
                return Ok(repository.Read(id));
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
