namespace backend.DTOs
{
    public class MechanicDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<DateTime> BookedDates { get; set; }
    }
}