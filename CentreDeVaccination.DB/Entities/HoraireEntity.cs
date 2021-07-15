using CentreDeVaccination.DB.Entities.Bases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Horaire")]
    public class HoraireEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        public string Jour { get; set; }

        [Required]
        public DateTime Ouverture { get; set; }

        [Required]
        public DateTime Fermeture { get; set; }

        public DateTime? OuvertureBis { get; set; }

        public DateTime? FermetureBis { get; set; }

        [Required]
        public TimeSpan DureePlageVaccination { get; set; }

        [Required]
        public int NbVaccinationParPlage { get; set; }

        [Required]
        public CentreVaccinationEntity CentreId { get; set; }

    }
}
