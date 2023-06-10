
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class CarToRepair : Car
    {
        [Required]
        public string RegistrationNumber { get; set;}
        [Required]
        public Guid IdUser { get; set; }
        [ForeignKey(nameof(IdUser))]
        public virtual Person User { get; set; }
    }
}