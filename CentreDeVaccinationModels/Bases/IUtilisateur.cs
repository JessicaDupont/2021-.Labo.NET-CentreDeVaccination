using System;
using System.Collections.Generic;
using System.Text;

namespace CentreDeVaccinationModels.Bases
{
    public interface IUtilisateur
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
