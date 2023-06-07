using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Customer : Person
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [JsonIgnore]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public virtual ICollection<Call> Calls { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}