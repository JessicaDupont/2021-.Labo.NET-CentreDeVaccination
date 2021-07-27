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
    public class LotController : ControllerBase
    {
        private readonly ILotRepository lotRepository;

        public LotController(ILotRepository lotRepository)
        {
            this.lotRepository = lotRepository;
        }
        //// GET: api/<LotController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<LotController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<LotController>
        [HttpPost]
        public ActionResult<string> AjouterLot([FromBody] LotForm value)
        {
            try
            {
                if (value is null) { return BadRequest(); }
                ILot result = lotRepository.Create(value);
                return Ok("Le lot a bien été ajouté");
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

        //// PUT api/<LotController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<LotController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
