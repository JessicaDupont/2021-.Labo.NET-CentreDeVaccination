using CentreDeVaccination.DB.Entities.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Adresse")]
    public class AdresseEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Rue { get; set; }

        [Required]
        [MaxLength(16)]
        public string Numero { get; set; }

        [Required]
        public int CodePostal { get; set; }

        [Required]
        [MaxLength(64)]
        public string Ville { get; set; }

        public bool IsVisible { get; set; }
    }
}
