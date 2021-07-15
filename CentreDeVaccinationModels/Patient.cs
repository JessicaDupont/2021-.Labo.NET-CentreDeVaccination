using CentreDeVaccinationModels.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentreDeVaccinationModels
{
    public class Patient : IUtilisateur
    {
        public Adresse Adresse { get; set; }
        public int Telephone { get; set; }
        public string InfosMedicales { get; set; }
        public int NumRegNat { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
