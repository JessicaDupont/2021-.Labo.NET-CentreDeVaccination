using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.IModels
{
    public interface ICentreDeVaccination : IModel
    {
        public IEnumerable<IHoraire> Horaire { get; set; }
        public IResponsable Responsable { get; set; }
    }
}
