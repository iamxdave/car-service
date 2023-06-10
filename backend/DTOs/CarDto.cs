using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class CarDto
    {
        public string Model { get; set; }
        public string? RegistrationNumber { get; set; }
        public int? Cost { get; set; }
        public int? Warranty { get; set; }
    }
}