using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.Forms;
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
    //TODO sécurisé accès dossier patient
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        //// GET: api/<PatientController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<PatientController>/5
        [HttpGet("{id}")]
        public ActionResult<IPatient> GetDossier(int id)
        {
            try
            {
                return Ok(patientRepository.Read(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Method = "GetDossier",
                        Message = ex.Message
                    });
            }
        }

        //// POST api/<PatientController>
        [HttpPost("[action]")]
        public ActionResult<string> Inscription([FromBody] PatientForm patient)
        {
            try
            {
                if (patient is null) { return BadRequest(); }
                IPatient result = patientRepository.Create(patient);
                return Ok("Le compte patient a bien été ajouté");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "POST/Inscription",
                    Message = ex.Message
                });
            }
        }

        //// PUT api/<PatientController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PatientController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
