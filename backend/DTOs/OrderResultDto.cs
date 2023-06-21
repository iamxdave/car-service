using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace backend.DTOs
{
    public class OrderResultDto
    {
        public Guid IdOrder { get; set; }
        public MechanicDto Mechanic { get; set; }
        public CarDto Car { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public OrderStatus Status { get; set; }
        public decimal? Cost { get; set; }
        public int? Warranty { get; set; }
        public PartDto[]? Parts { get; set; }
    }
}