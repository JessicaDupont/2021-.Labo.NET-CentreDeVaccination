using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IPersonne : IModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
