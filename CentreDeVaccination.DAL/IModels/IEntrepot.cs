using System.Collections.Generic;

namespace CentreDeVaccination.DAL.IModels
{
    public interface IEntrepot : IModel
    {
        public string Nom { get; set; }

        public IAdresse Adresse { get; set; }

        /// <summary>
        /// fournit la liste des vaccins disponibles dans cet entrepot
        /// </summary>
        public IEnumerable<IVaccin> Vaccins { get; set; }
    }
}