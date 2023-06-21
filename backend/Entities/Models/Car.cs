using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public abstract class Car
    {
        [Key]
        public Guid IdCar { get; set; }
        [Required]
        public int IdWorkshop { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [ForeignKey(nameof(IdWorkshop))]
        public virtual Workshop Workshop { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }

    }
}