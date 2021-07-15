using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Entrepot : IEntrepot
    {
        public string Nom { get; set; }
        public IAdresse Adresse { get; set; }
        public IEnumerable<IVaccin> Vaccins { get; set; }
        public int Id { get; set; }
    }
}
