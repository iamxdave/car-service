using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class MechanicOrder
    {
        [Key]
        public int IdMechanicOrder { get; set; }
        [Required]
        public int IdMechanic { get; set; }
        [Required]
        public int IdOrder { get; set; }
        [ForeignKey(nameof(IdMechanic))]
        public Mechanic Mechanic { get; set; }
        [ForeignKey(nameof(IdOrder))]
        public Order Order { get; set; }
    }
}