using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class CarDto
    {
        public Guid? IdCar { get; set; }
        public int IdWorkshop { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string? RegistrationNumber { get; set; }
        public int? Cost { get; set; }
        public string? Description { get; set; }
    }
}