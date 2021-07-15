using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.IModels
{
    public interface IUtilisateurProfil : IModel
    {
        public string Email { get; set; }
        public byte[] Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public IUtilisateurPublic Check(string email, string mdp);
    }
}
