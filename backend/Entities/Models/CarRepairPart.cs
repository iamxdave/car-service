using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CarRepairPart
    {
        [Key]
        public int IdCarRepairPart { get; set; }
        [Required]
        public int IdCarRepair { get; set; }
        [Required]
        public int IdPart { get; set; }
        [ForeignKey(nameof(IdCarRepair))]
        public CarRepair CarRepair { get; set; }
        [ForeignKey(nameof(IdPart))]
        public Part Part { get; set; }
    }
}