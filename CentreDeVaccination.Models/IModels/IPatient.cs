using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IPatient : IModel
    {
        public int Id { get; set; }
        public string NumRegNat { get; set; }
        public string NumTel { get; set; }
        public IAdresse Adresse { get; set; }
        public string InfosMed { get; set; }
        public IPersonne Personne { get; set; }
        public IEnumerable<IRendezVous> RDVs { get; set; }
    }
}
