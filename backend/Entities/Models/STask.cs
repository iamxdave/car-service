using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class STask
    {
        [Key]
        public int IdSTask { get; set; }
        [Required]
        public int IdCar { get; set; }
        [Required]
        public int IdOrder { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [ForeignKey(nameof(IdCar))]
        public virtual Car Car { get; set; }
        [ForeignKey(nameof(IdOrder))]
        public virtual Order Order { get; set; }
        public virtual ICollection<MechanicSTask> MechanicSTasks { get; set; }
    }
}