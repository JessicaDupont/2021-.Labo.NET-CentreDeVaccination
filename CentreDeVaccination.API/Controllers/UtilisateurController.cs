using CentreDeVaccination.DAL.Repositories;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.Models;
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
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurRepository utilisateurRepository;
        //private readonly IOptions<JWTSettings> jwtSettings;

        public UtilisateurController(IUtilisateurRepository utilisateurRepository/*, IOptions<JWTSettings> jwtSettings*/)
        {
            this.utilisateurRepository = utilisateurRepository;
            //this.jwtSettings = jwtSettings;
        }
        //// GET: api/<UtilisateurController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UtilisateurController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UtilisateurController>
        [HttpPost("[action]")]
        public ActionResult<string> Inscription([FromBody] UtilisateurProfil profil)
        {            
            try
            {
                if (profil is null) { return BadRequest(); }
                IUtilisateur result = utilisateurRepository.Create(profil);

                return Ok("Le compte utilisateur a bien été créé.");
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

        //// POST api/<UtilisateurController>
        [HttpPost("[action]")]
        public ActionResult<IUtilisateur> Connexion(string email, string mdp)
        {
            try
            {
                IUtilisateur result = utilisateurRepository.Check(email, mdp);
                if (result is null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized,
                        "Cette combinaison login/mot de passe n'a pas été trouvée.");
                }

                //TODO fournir un token
                //Token tok = new Token(jwtSettings);
                //result.Token = tok.Create(email);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "POST/Connexion",
                    Message = ex.Message
                });
            }
        }

        //// PUT api/<UtilisateurController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UtilisateurController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
