using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IChamp
    {
        string Nom { get; set; }
        object Valeur { get; set; }
    }
}
