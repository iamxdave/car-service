using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.Models
{
    public class CarForSale : Car
    {
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Warranty { get; set; }
    }
}