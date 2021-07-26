using CentreDeVaccination.Models.Forms.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.Forms
{
    public class RdvForm : IForm
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int VaccinChoisiId { get; set; }
        public int CentreId { get; set; }
        public DateTime RendezVous { get; set; }
    }
}
