using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Buyout : Order
    {
        [Required]
        public int Warranty { get; set; } = 5;
    }
}