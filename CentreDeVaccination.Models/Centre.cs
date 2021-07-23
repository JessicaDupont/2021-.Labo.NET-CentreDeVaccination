using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;

namespace CentreDeVaccination.Models
{
    public class Centre : ICentreDeVaccination
    {
        public IEntrepot Entrepot { get; set; }
        public IEmploye Responsable { get; set; }
        public IEnumerable<IHoraire> Horaire { get; set; }
        public int Id { get; set; }
        public IEnumerable<IEmploye> Equipe { get; set; }
    }
}
