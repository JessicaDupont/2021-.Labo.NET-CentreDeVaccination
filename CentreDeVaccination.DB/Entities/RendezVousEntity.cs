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
        public int PatientId { get; set; }
        public virtual PatientEntity Patient { get; set; }

        [Required]
        public int CentreId { get; set; }
        public virtual CentreVaccinationEntity Centre { get; set; }

        [Required]
        public int VaccinId { get; set; }
        public virtual VaccinEntity Vaccin { get; set; }

        [Required]
        public DateTime RendezVous { get; set; }

        public int PersonnelId { get; set; }
        public virtual PersonnelEntity Personnel { get; set; }

        public int LotId { get; set; }
        public virtual LotEntity Lot { get; set; }

        public bool IsVisible { get; set; }
    }
}
