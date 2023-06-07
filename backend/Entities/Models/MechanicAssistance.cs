using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class MechanicAssistance
    {
        [Key]
        public int IdMechanicSTask { get; set; }
        [Required]
        public int IdMechanic { get; set; }
        [Required]
        public int IdAssistance { get; set; }
        [ForeignKey(nameof(IdMechanic))]
        public Mechanic Mechanic { get; set; }
        [ForeignKey(nameof(IdAssistance))]
        public Assistance Assistance { get; set; }
    }
}