using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Responsable : IResponsable
    {
        public string NumInami { get; set; }
        public Grades Grade { get; set; }
        public int Id { get; set; }

        public bool VerifInami(string num)
        {
            throw new NotImplementedException();
        }
    }
}
