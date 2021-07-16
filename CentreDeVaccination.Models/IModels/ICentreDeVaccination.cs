using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface ICentreDeVaccination : IModel
    {
        public IEntrepot Entrepot();
        public IEnumerable<IHoraire> Horaire();
        public IResponsable Responsable();
        public IEnumerable<IVaccin> Vaccins();
    }
}
