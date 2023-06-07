using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Employee : Person
    {
        [Required]
        public int IdWorkshop { get; set; }
        [Required]
        public DateTime EmploymentDate { get; set; }
        [Required]
        public decimal MonthlySalary { get; set; }
        [ForeignKey(nameof(IdWorkshop))]
        public virtual Workshop Workshop { get; set; }
    }
}