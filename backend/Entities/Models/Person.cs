using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public abstract class Person
    {
        [Key]
        public Guid IdPerson { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }

}