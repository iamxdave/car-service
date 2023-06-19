using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Repair : Order
    {
        [Required]
        public decimal TotalPartCost { get; set; }
        public virtual IEnumerable<RepairPart> RepairParts { get; set; }
    }
}