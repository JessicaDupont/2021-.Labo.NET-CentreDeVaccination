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

        //[ForeignKey(nameof(UtilisateurEntity))]
        public UtilisateurEntity UtilisateurId { get; set; }

        [Required]
        [MaxLength(16)]
        public string NumRegNat { get; set; }

        [Required]
        [ForeignKey(nameof(AdresseEntity))]
        public AdresseEntity AdresseId { get; set; }

        [MaxLength(16)]
        public string NumTelephone { get; set; }

        public string? InformationMedicales { get; set; }

        public virtual IEnumerable<RendezVousEntity> RDVs { get; set; }
    }
}
