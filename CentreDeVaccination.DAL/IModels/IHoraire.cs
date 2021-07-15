using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.IModels
{
    public interface IHoraire : IModel
    {
        public string Jour { get; set; }
        public DateTime Ouverture { get; set; }
        public DateTime Fermeture { get; set; }
        public DateTime? OuvertureBis { get; set; }
        public DateTime? FermetureBis { get; set; }
        public int DureePlageVaccination { get; set; }
        public int NbVaccinationParPlage { get; set; }
    }
}
