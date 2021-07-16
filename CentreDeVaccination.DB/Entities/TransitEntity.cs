using CentreDeVaccination.DB.Entities.Bases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentreDeVaccination.DB.Entities
{
    [Table("Transit")]
    public class TransitEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int EntrepotId { get; set; }
        public virtual EntrepotEntity Entrepot { get; set; }

        [Required]
        public int LotId { get; set; }
        public virtual LotEntity Lot { get; set; }

        [Required]
        public DateTime DateEntree { get; set; }

        public DateTime? DateSortie { get; set; }

    }
}
