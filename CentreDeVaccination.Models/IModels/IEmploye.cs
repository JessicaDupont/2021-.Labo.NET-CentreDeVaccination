using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IEmploye : IModel
    {
        public IPersonne Personne { get; set; }
        public Grades Grade { get; set; }
        public ICentreDeVaccination Centre { get; set; }
        public bool ResponsableCentre { get; set; }
        public string? Inami { get; set; }
        public bool VerifInami();
    }
}
