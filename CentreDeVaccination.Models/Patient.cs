using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Patient : IPatient
    {
        public string NumRegNat { get; set; }
        public string NumTel { get; set; }
        public IAdresse Adresse { get; set; }
        public string InfosMed { get; set; }
        public int Id { get; set; }

        public IPersonne Personne { get; set; }
    }
}
