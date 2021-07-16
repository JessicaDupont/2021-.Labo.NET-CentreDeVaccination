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
        public IEnumerable<IHoraire> Horaire { get; set; }
        public IEnumerable<IChamp> ChampsRecherche { get; set; }

        public IResponsable Responsable();
        public IEnumerable<IVaccin> Vaccins();
    }
}
