namespace DTOs
{
    public class OrderDto
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }
        public decimal Cost { get; set; }
    }
}