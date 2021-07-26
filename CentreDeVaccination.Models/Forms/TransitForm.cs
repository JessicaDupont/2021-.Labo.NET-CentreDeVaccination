using CentreDeVaccination.Models.Forms.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.Forms
{
    public class TransitForm : IForm
    {
        public int Id { get; set; }
        public int EntrepotId { get; set; }
        public int LotId { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime? DateSortie { get; set; }
    }
}
