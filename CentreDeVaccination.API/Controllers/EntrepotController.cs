using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.Models.Forms;
using CentreDeVaccination.Models.IModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentreDeVaccination.API.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntrepotController : ControllerBase
    {
        private readonly IEntrepotRepository entrepotRepository;

        public EntrepotController(IEntrepotRepository entrepotRepository)
        {
            this.entrepotRepository = entrepotRepository;
        }
        //// GET: api/<TransitController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<TransitController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TransitController>
        [HttpPost("[action]")]
        public ActionResult<string> LivraisonLotVaccins([FromBody] TransitForm value)
        {
            try
            {
                if (value is null) { return BadRequest(); }
                IEntrepot result = entrepotRepository.Create(value);
                return Ok("La livraison a bien été ajoutée");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "POST/Livraison",
                    Message = ex.Message
                });
            }
        }

        //// PUT api/<TransitController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TransitController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
