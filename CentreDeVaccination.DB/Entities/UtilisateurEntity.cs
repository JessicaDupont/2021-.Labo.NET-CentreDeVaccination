using CentreDeVaccination.DB.Entities.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Utilisateur")]
    public class UtilisateurEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public byte[] MotDePasse { get; set; }

        [MaxLength(64)]
        public string? Nom { get; set; }

        [MaxLength(64)]
        public string? Prenom { get; set; }

        public bool IsVisible { get; set; }
    }
}
