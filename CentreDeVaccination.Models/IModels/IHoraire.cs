using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IHoraire : IModel
    {
        public string Jour { get; set; }
        public DateTime Ouverture { get; set; }
        public DateTime Fermeture { get; set; }
        public DateTime? OuvertureBis { get; set; }
        public DateTime? FermetureBis { get; set; }
        public TimeSpan DureePlageVaccination { get; set; }
        public int NbVaccinationParPlage { get; set; }
    }
}
