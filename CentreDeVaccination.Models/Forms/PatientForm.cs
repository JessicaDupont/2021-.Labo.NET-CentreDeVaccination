using CentreDeVaccination.Models.Forms.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.Forms
{
    public class PatientForm : IForm
    {
        public string NumRegNat { get; set; }
        public string NumTel { get; set; }
        public int AdresseId { get; set; }
        public string InfosMed { get; set; }
        public int Id { get; set; }

        public int UtilisateurId { get; set; }
    }
}
