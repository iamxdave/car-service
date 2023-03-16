using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class MechanicSTask
    {
        [Key]
        public int IdMechanicSTask { get; set; }
        [Required]
        public int IdMechanic { get; set; }
        [Required]
        public int IdSTask { get; set; }
        [ForeignKey(nameof(IdMechanic))]
        public Mechanic Mechanic { get; set; }
        [ForeignKey(nameof(IdSTask))]
        public STask STask { get; set; }
    }
}