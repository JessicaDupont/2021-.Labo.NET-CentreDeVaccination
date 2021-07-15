using System;
using System.Collections.Generic;
using System.Text;

namespace CentreDeVaccinationModels
{
    public class Vaccin
    {
        private string? nom;

        public string Fabricant { get; set; }
        public string Nom {
            get => nom is null ? Fabricant : nom;
            set => nom = value; 
        }
        /// <summary>
        /// nombre de jours minimum entre 2 injections
        /// </summary>
        public int IntervalleMinimum { get; set; }
        /// <summary>
        /// nombre de jours maximum entre 2 injections
        /// </summary>
        public int IntervalleMaximum { get; set; }
    }
}
