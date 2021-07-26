using CentreDeVaccination.Models.Forms.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.Forms
{
    public class InjectionForm : IForm
    {
        public int RdvId { get; set; }
        public int SoignantId { get; set; }
        public int LotId { get; set; }
    }
}
