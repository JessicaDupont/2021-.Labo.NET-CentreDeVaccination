using CentreDeVaccination.DB.Entities.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Personnel")]
    public class PersonnelEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UtilisateurId { get; set; }
        public virtual UtilisateurEntity Utilisateur { get; set; }

        public int CentreId { get; set; }
        public virtual CentreVaccinationEntity Centre { get; set; }

        public bool ResponsableCentre { get; set; }

        [Required]
        [MaxLength(16)]
        public string Grade { get; set; }

        [MaxLength(16)]
        public string? NumInami { get; set; }

        public bool IsVisible { get; set; }

        public virtual IEnumerable<RendezVousEntity> RDVs { get; set; }
    }
}
