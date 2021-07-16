using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;

namespace CentreDeVaccination.Models
{
    public class Centre : ICentreDeVaccination
    {
        public int Id { get; set; }

        public IEntrepot Entrepot()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHoraire> Horaire()
        {
            throw new NotImplementedException();
        }

        public IResponsable Responsable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVaccin> Vaccins()
        {
            throw new NotImplementedException();
        }
    }
}
