namespace Entities.Models
{
    public class CarRepair : STask
    {
        public virtual IEnumerable<CarRepairPart> CarRepairParts { get; set; }
    }
}