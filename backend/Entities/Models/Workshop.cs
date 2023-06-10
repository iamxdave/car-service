using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Workshop
    {
        [Key]
        public int IdWorkshop { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime OpeningTime { get; } = new DateTime(1, 1, 1, 9, 0, 0).ToUniversalTime();
        [Required]
        public DateTime ClosingTime { get; } = new DateTime(1, 1, 1, 22, 0, 0).ToUniversalTime();
        public virtual ICollection<Mechanic> Mechanics { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}