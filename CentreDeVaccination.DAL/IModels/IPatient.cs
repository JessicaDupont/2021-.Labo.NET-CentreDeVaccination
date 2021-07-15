using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.IModels
{
    public interface IPatient : IModel
    {
        public int NumRegNat { get; set; }
        public int NumTel { get; set; }
        public IAdresse Adresse { get; set; }
        public string InfosMed { get; set; }
    }
}
