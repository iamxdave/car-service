using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Service
    {
        [Key]
        public int IdService { get; set; }
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
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}