using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CSRepresentative : Employee
    {
        [Required]
        public int ProcessedCallsCount { get; set; }
        public virtual ICollection<Call> Calls { get; set; }
    }
}