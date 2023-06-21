using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Mechanic : Person
    {
        [Required]
        public List<Reservation> BookedDates { get; set; }
        [Required]
        public int IdWorkshop { get; set; }
        [ForeignKey(nameof(IdWorkshop))]
        public virtual Workshop Workshop { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
    [Owned]
    public class Reservation {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}