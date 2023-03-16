using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        [Required]
        public int IdCustomer { get; set; }
        [Required]
        public int IdSTask { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime? DateCompleted { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [ForeignKey(nameof(IdCustomer))]
        public Person Customer { get; set; }
        [ForeignKey(nameof(IdSTask))]
        public STask STask { get; set; }
        public ICollection<MechanicOrder> MechanicOrders { get; set; }
    }

    public enum OrderStatus
    {
        Accepted,
        InProgress,
        Completed,
        Cancelled
    }
}