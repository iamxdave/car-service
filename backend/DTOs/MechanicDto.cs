using Entities.Models;

namespace backend.DTOs
{
    public class MechanicDto
    {
        public Guid IdPerson { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Reservation> BookedDates { get; set; }
    }
}