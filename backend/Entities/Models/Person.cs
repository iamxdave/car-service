using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Person
    {
        [Key]
        public int IdPerson { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }

}