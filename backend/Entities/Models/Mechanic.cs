using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Mechanic : Person
    {
        [Required]
        public List<DateTime> BookedDates { get; set; }
        [Required]
        public int IdWorkshop { get; set; }
        [ForeignKey(nameof(IdWorkshop))]
        public virtual Workshop Workshop { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}