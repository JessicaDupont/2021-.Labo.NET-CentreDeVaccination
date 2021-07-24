using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class UtilisateurProfil : IUtilisateurProfil
    {
        public string Email { get; set; }
        public string Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Id { get; set; }

        public IUtilisateur Check(string email, string mdp)
        {
            throw new NotImplementedException();
        }
    }
}
