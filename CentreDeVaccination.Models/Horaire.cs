using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Horaire : IHoraire
    {
        public string Jour { get; set; }
        public DateTime Ouverture { get; set; }
        public DateTime Fermeture { get; set; }
        public DateTime? OuvertureBis { get; set; }
        public DateTime? FermetureBis { get; set; }
        public TimeSpan DureePlageVaccination { get; set; }
        public int NbVaccinationParPlage { get; set; }
        public int Id { get; set; }
    }
}
