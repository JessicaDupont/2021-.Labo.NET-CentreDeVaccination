using CentreDeVaccination.DB.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Lot")]
    public class LotEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string NumLot { get; set; }

        [Required]
        public int NbDoses { get; set; }

        public int NbDosesRestantes { get; set; }

        [Required]
        public VaccinEntity VaccinId { get; set; }

        public virtual IEnumerable<TransitEntity> Transits { get; set; }

        public virtual IEnumerable<RendezVousEntity> RDVs { get; set; }

    }
}
