using CentreDeVaccinationModels.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentreDeVaccinationModels
{
    public class CentreDeVaccination
    {
        public Adresse Adresse { get; set; }
        public PersonnelSoignant Responsable { get; set; }
        public string Nom { get; set; }
        /// <summary>
        /// durée d'une plage en minutes
        /// </summary>
        public int DureePlage { get; set; }
        /// <summary>
        /// nombre maximum de patient pouvant être vaccinés lors d'une plage horaire définie par Dureeplage
        /// </summary>
        public int NbPatientPlage { get; set; }

        public IEnumerable<Horaire> Horaire { get; set; }
        public IEnumerable<IPersonnel> Personnel { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
    }
}
