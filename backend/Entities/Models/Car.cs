using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }
        [Required]
        public int IdCustomer { get; set; }
        [Required]
        public int IdService { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public CarType Type { get; set; }
        [ForeignKey(nameof(IdCustomer))]
        public virtual Person Customer { get; set; }
        [ForeignKey(nameof(IdService))]
        public virtual Service Service { get; set; }
        public virtual IEnumerable<STask> STasks { get; set; }

    }

    public enum CarType
    {
        Sedan,
        SUV,
        Truck
    }
}