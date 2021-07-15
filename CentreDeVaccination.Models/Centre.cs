using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;

namespace CentreDeVaccination.Models
{
    public class Centre : ICentreDeVaccination
    {
        public IEntrepot Entrepot { get; set; }
        public IEnumerable<IHoraire> Horaire { get; set; }
        public IResponsable Responsable { get; set; }
        public IEnumerable<IChamp> ChampsRecherche { get; set; }
        public int Id { get; set; }
    }
}
