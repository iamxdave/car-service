using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.Models
{
    public class CarToRepair : Car
    {
        [Required]
        public int IdCustomer { get; set; }
        [ForeignKey(nameof(IdCustomer))]
        public virtual Person Customer { get; set; }
    }
}