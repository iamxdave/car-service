using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Mechanic : Employee
    {
        [Required]
        public List<DateTime> BookedDates { get; set; }
        public virtual IEnumerable<MechanicAssistance> MechanicAssistance{ get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}