using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.Models
{
    public class Transit : ITransit
    {
        public ILot Lot { get; set; }
        public IEntrepot Entrepot { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime? DateSortie { get; set; }
        public int Id { get; set; }
    }
}
