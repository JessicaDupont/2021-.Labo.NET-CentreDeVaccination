using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities.Bases
{
    public interface IEntity
    {
        public int Id { get; set; }

        public bool IsVisible { get; set; }
    }
}
