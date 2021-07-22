using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface ISoignant : IPersonnel
    {
        public bool ResponsableCentre { get; set; }
        public string Inami { get; set; }
        public bool VerifInami();
    }
}
