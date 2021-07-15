using CentreDeVaccination.DB.Entities.Bases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("RendezVous")]
    public class RendezVousEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(PatientEntity))]
        public PatientEntity PatientId { get; set; }

        [Required]
        public CentreVaccinationEntity CentreId { get; set; }

        [Required]
        public VaccinEntity VaccinId { get; set; }

        [Required]
        public DateTime RendezVous { get; set; }

        public PersonnelEntity PersonnelId { get; set; }

        public LotEntity LotId { get; set; }
    }
}
