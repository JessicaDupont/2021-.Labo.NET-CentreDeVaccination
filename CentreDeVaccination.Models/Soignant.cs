using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Soignant : ISoignant
    {
        public bool ResponsableCentre { get; set; }
        public string Inami { get; set; }
        public Grades Grade { get; set; }
        public int Id { get; set; }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Token { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Nom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Prenom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool VerifInami()
        {
            throw new NotImplementedException();
        }
    }
}
