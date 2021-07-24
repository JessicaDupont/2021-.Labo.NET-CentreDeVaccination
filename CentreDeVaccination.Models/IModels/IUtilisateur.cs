using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IUtilisateur : IModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public IPersonne Personne { get; set; }
        public IPatient? Patient { get; set; }
        public IEmploye? Employe { get; set; }
    }
}
