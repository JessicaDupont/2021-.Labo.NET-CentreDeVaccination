using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Utilisateur : IUtilisateur
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public IPatient Patient { get; set; }
        public IEmploye Employe { get; set; }
        public int Id { get; set; }
    }
}
