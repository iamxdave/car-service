using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CarSale : STask
    {
        [Required]
        public int ManufacturerWarranty { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}