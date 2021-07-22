using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface ICentreDeVaccination : IModel
    {
        public IEntrepot Entrepot { get; set; }
        public IPersonnel Responsable { get; set; }
        public IEnumerable<IHoraire> Horaire { get; set; }
        public IEnumerable<IPersonnel> Equipe { get; set; }
    }
}
