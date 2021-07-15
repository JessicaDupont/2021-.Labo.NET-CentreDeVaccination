using System;
using System.Collections.Generic;
using System.Text;

namespace CentreDeVaccinationModels.Bases
{
    public interface IPersonnel : IUtilisateur
    {
        public string Grade { get; set; }
        public CentreDeVaccination Centre { get; set; }
    }
}
