namespace DTOs
{
    public class OrderGet
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }
        public decimal Cost { get; set; }
    }
}