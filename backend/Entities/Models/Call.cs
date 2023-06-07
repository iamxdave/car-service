using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Call
    {
        [Key]
        public int IdCall { get; set; }
        [Required]
        public int IdCustomer { get; set; }
        [Required]
        public int IdCustomerServiceRepresentative { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(IdCustomer))]
        public virtual Person Customer { get; set; }
        [ForeignKey(nameof(IdCustomerServiceRepresentative))]
        public virtual CustomerServiceRepresentative CustomerServiceRepresentative { get; set; }
    }
}