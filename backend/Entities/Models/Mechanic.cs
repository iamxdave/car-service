using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Mechanic : Employee
    {
        [Required]
        public int RepairedCarsCount { get; set; }
        public virtual IEnumerable<MechanicSTask> MechanicSTasks { get; set; }
        public virtual IEnumerable<MechanicOrder> MechanicOrders { get; set; }
    }
}