using backend.DTOs;

namespace DTOs
{
    public class OrderDto
    {
        public Guid IdOrder { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdMechanic { get; set; }
        public Guid IdCar { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }
        public decimal? Cost { get; set; }
        public int? Warranty { get; set; }
        public PartDto[]? Parts { get; set; }
    }
}