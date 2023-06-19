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
        public virtual ICollection<Mechanic> Mechanics { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}