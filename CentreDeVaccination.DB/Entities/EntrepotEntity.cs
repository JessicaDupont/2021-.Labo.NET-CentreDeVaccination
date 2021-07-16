using CentreDeVaccination.DB.Entities.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Entrepot")]
    public class EntrepotEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Nom { get; set; }

        [Required]
        public int AdresseId { get; set; }
        public virtual AdresseEntity Adresse { get; set; }

        public virtual IEnumerable<TransitEntity> Transits { get; set; }
    }
}
