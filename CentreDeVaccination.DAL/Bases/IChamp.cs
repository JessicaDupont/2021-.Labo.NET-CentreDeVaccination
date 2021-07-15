using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Bases
{
    public interface IChamp
    {
        string Nom { get; set; }
        object Valeur { get; set; }
    }
}
