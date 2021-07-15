using CentreDeVaccinationModels.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentreDeVaccinationModels
{
    public class PersonnelSoignant : IPersonnel
    {
        public string Inami { get; set; }
        public string Grade { get; set; }
        public CentreDeVaccination Centre { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
