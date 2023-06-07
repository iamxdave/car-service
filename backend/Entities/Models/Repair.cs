namespace Entities.Models
{
    public class Repair : Assistance
    {
        public virtual IEnumerable<RepairPart> RepairParts { get; set; }
    }
}