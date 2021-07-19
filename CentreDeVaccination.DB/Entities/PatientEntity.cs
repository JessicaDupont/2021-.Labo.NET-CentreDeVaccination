using CentreDeVaccination.DB.Entities.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Patient")]
    public class PatientEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int UtilisateurId { get; set; }
        public virtual UtilisateurEntity Utilisateur { get; set; }

        [Required]
        [MaxLength(16)]
        public string NumRegNat { get; set; }

        [Required]
        public int AdresseId { get; set; }
        public AdresseEntity Adresse { get; set; }

        [MaxLength(16)]
        public string NumTelephone { get; set; }

        public string? InformationMedicales { get; set; }

        public bool IsVisible { get; set; }

        public virtual IEnumerable<RendezVousEntity> RDVs { get; set; }
    }
}
