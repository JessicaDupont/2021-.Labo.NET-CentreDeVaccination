using CentreDeVaccination.DAL.Repositories;
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
    public class RdvController : ControllerBase
    {
        private readonly IRdvRepository rdvRepository;

        public RdvController(IRdvRepository rdvRepository)
        {
            this.rdvRepository = rdvRepository;
        }
        //// GET: api/<RdvController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<RdvController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RdvController>
        [HttpPost("[action]")]
        public ActionResult<string> AjoutRdv([FromBody] RdvForm form)
        {
            try
            {
                if (form is null) { return BadRequest(); }
                IRendezVous result = rdvRepository.Create(form);
                return Ok("Le rdv a bien été ajouté");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "POST/AjoutRdv",
                    Message = ex.Message
                });
            }
        }
        // POST api/<RdvController>
        [HttpPost("[action]")]
        public ActionResult<string> Injection([FromBody] InjectionForm form)
        {
            try
            {
                if (form is null) { return BadRequest(); }
                IRendezVous result = rdvRepository.Injection(form);
                return Ok("L'injection a bien été ajoutée au rdv.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "POST/AjoutRdv",
                    Message = ex.Message
                });
            }
        }

        //// PUT api/<RdvController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RdvController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
