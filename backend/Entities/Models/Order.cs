using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public abstract class Order
    {
        [Key]
        public Guid IdOrder { get; set; }
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public Guid IdMechanic { get; set; }
        [Required]
        public Guid IdCar { get; set; }
        [Required]
        public DateTime DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [ForeignKey(nameof(IdUser))]
        public virtual Person Customer { get; set; }
        [ForeignKey(nameof(IdMechanic))]
        public virtual Mechanic Mechanic { get; set; }
        [ForeignKey(nameof(IdCar))]
        public virtual Car Car { get; set; }
        public void deleteCancelledOrders()
        {
            throw new NotImplementedException();
        }
    }

    public enum OrderStatus
    {
        Accepted,
        InProgress,
        Completed,
        Cancelled
    }
}