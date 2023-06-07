namespace backend.DTOs
{
    public class MechanicGet
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<DateTime> BookedDates { get; set; }
    }
}