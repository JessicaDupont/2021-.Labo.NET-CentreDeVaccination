using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.IModels
{
    public interface ILot : IModel
    {
        public IVaccin Vaccin { get; set; }
        public string NumLot { get; set; }
        public int QtDoses { get; set; }
    }
}
