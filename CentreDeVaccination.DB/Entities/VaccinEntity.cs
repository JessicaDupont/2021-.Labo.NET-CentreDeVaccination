using CentreDeVaccination.DB.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Vaccin")]
    public class VaccinEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Fabricant { get; set; }

        [MaxLength(64)]
        public string? Nom { get; set; }

        [Required]
        public int NbJoursIntervalleMinimum { get; set; }

        [Required]
        public int NbJoursIntervalleMaximum { get; set; }

        public virtual IEnumerable<RendezVousEntity> RDVs { get; set; }

        public virtual IEnumerable<LotEntity> Lots { get; set; }
    }
}
