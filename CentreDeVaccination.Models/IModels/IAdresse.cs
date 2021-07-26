using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IAdresse : IModel
    {
        public new int Id { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
    }
}
