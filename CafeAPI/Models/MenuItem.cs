using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeAPI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
