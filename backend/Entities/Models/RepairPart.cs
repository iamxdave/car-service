using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class RepairPart
    {
        [Key]
        public int IdRepairPart { get; set; }
        [Required]
        public int Quality { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public Guid IdRepair { get; set; }
        [Required]
        public int IdPart { get; set; }
        [ForeignKey(nameof(IdRepair))]
        public Repair Repair { get; set; }
        [ForeignKey(nameof(IdPart))]
        public Part Part { get; set; }
    }
}