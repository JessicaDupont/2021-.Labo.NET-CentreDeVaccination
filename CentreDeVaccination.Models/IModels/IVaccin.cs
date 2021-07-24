using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models.IModels
{
    public interface IVaccin : IModel
    {
        public int Id { get; set; }
        public string Fabricant { get; set; }
        public string Nom { get; set; }
        public TimeSpan IntervalleMin { get; set; }
        public TimeSpan IntervalleMax { get; set; }
    }
}
