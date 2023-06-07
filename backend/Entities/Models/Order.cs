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
        public int IdAssistance { get; set; }
        [Required]
        public int IdMechanic { get; set; }
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
        [ForeignKey(nameof(IdAssistance))]
        public Assistance Assistance { get; set; }
        [ForeignKey(nameof(IdMechanic))]
        public Mechanic Mechanic { get; set; }
    }

    public enum OrderStatus
    {
        Accepted,
        InProgress,
        Completed,
        Cancelled
    }
}