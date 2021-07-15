using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IInfirmier : IPersonnel
    {
        public string? NumInami { get; set; }
        public string? NumVisa { get; set; }

        /// <summary>
        /// https://www.inami.fgov.be/fr/professionnels/autres/fournisseurs-logiciels/Pages/default.aspx#Pour_vos_d%C3%A9veloppements_li%C3%A9s_aux_num%C3%A9ros_INAMI
        /// </summary>
        public bool VerifInami(string num);
        public bool VerifVisa(string num);
    }
}
