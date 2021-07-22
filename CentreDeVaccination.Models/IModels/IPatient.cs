using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IPatient : IUtilisateurPublic
    {
        public int NumRegNat { get; set; }
        public int NumTel { get; set; }
        public IAdresse Adresse { get; set; }
        public string InfosMed { get; set; }
    }
}
