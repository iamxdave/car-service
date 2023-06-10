using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Part
    {
        [Key]
        public int IdPart { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<RepairPart> RepairParts { get; set; }
    }
}