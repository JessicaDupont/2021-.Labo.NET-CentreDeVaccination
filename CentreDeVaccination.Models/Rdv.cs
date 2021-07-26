using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Rdv : IRendezVous
    {
        public int Id { get; set; }
        public IPatient Patient { get; set; }
        public IVaccin VaccinChoisi { get; set; }
        public ICentreDeVaccination Centre { get; set; }
        public DateTime RendezVous { get; set; }
        public IEmploye Soignant { get; set; }
        public ILot Lot { get; set; }

        public void Injection(IEmploye soignant, ILot Lot)
        {
            throw new NotImplementedException();
        }
    }
}
