using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecureSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int ProductId { get; set; } 
        public Product Product { get; set; }

    }
}
