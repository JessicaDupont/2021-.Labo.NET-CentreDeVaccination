using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.IModels
{
    public interface IRendezVous : IModel
    {
        public IPatient Patient { get; set; }
        public IVaccin VaccinChoisi { get; set; }
        public ICentreDeVaccination Centre { get; set; }
        public DateTime RendezVous { get; set; }
        public ISoignant? Soignant { get; set; }
        public ILot? Lot { get; set; }

        public void Injection(ISoignant soignant, ILot Lot);
    }
}
