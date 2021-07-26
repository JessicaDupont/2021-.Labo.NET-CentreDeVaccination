using CentreDeVaccination.Models.Forms.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.Forms
{
    public class LotForm : IForm
    {
        public int VaccinId { get; set; }
        public string NumLot { get; set; }
        public int QtDoses { get; set; }
        public int Id { get; set; }
        public int EntrepotId { get; set; }
        public DateTime DateEntree { get; set; }
    }
}
