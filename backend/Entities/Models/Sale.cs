using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Sale : Order
    {
        [Required]
        public int SaleCost { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}