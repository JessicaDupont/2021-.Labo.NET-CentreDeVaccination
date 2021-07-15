using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface ILot : IModel
    {
        public IVaccin Vaccin { get; set; }
        public string NumLot { get; set; }
        public int QtDoses { get; set; }
    }
}
