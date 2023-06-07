using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Assistance
    {
        [Key]
        public int IdAssistance { get; set; }
        [Required]
        public int IdCar { get; set; }
        [Required]
        public int IdOrder { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [ForeignKey(nameof(IdCar))]
        public virtual Car Car { get; set; }
        public virtual ICollection<MechanicAssistance> MechanicAssistance { get; set; }
    }
}