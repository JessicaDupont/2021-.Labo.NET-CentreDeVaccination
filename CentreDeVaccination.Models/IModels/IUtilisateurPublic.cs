using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IUtilisateurPublic : IModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
