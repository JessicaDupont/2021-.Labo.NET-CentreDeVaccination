using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface ICentreDeVaccination : IModel
    {
        public int Id { get; set; }
        public IEntrepot Entrepot { get; set; }
        public IEmploye Responsable { get; set; }
        public IEnumerable<IHoraire> Horaire { get; set; }
        public IEnumerable<IEmploye> Equipe { get; set; }
    }
}
